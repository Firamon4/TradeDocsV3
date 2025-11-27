using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class SettingsForm : Form
{
    private readonly AppSettings _settings;
    private readonly UserRepository _userRepo;

    // Прапорці змін для кожної вкладки
    private bool _dirtyConn = false;
    private bool _dirtyMap = false;

    // Тимчасовий список для маппінгів (редагуємо його, а не основний конфіг, поки не збережемо)
    private List<DataContextMap> _tempMappings = new();

    public SettingsForm(AppSettings settings)
    {
        InitializeComponent();
        _settings = settings;
        _userRepo = new UserRepository(_settings);

        // Клонуємо маппінги, щоб можна було "Відмінити зміни"
        CloneMappings();

        this.Load += SettingsForm_Load;
        this.FormClosing += SettingsForm_FormClosing;
    }

    private void CloneMappings()
    {
        // Глибоке копіювання списку маппінгів через JSON (найпростіший спосіб)
        string json = JsonSerializer.Serialize(_settings.Sync.Mappings);
        _tempMappings = JsonSerializer.Deserialize<List<DataContextMap>>(json) ?? new List<DataContextMap>();
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        // TAB 1 LOAD
        txtMssql.Text = _settings.Database.EncryptedMSSQL;
        txtSqlite.Text = _settings.Database.EncryptedSQLite;
        chkEncrypt.Checked = _settings.Security.UseEncryption;

        txtMssql.TextChanged += (s, a) => SetDirtyConn();
        txtSqlite.TextChanged += (s, a) => SetDirtyConn();
        chkEncrypt.CheckedChanged += (s, a) => SetDirtyConn();

        // TAB 2 LOAD
        RefreshMapsGrid();

        _dirtyConn = false;
        _dirtyMap = false;
        UpdateButtons();
    }

    private void SetDirtyConn() { _dirtyConn = true; UpdateButtons(); }
    private void SetDirtyMap() { _dirtyMap = true; UpdateButtons(); }

    private void UpdateButtons()
    {
        btnSaveConn.Enabled = _dirtyConn;
        btnCancelConn.Enabled = _dirtyConn;

        btnSaveMap.Enabled = _dirtyMap;
        btnCancelMap.Enabled = _dirtyMap;

        this.Text = (_dirtyConn || _dirtyMap) ? "Налаштування системи *" : "Налаштування системи";
    }

    // ================== TAB 1: CONNECTIONS ==================

    private void btnSaveConn_Click(object sender, EventArgs e)
    {
        _settings.Database.EncryptedMSSQL = txtMssql.Text.Trim();
        _settings.Database.EncryptedSQLite = txtSqlite.Text.Trim();
        _settings.Security.UseEncryption = chkEncrypt.Checked;

        ConfigManager.Save(_settings);
        try { _userRepo.EnsureMssqlTables(); } catch { }

        _dirtyConn = false;
        UpdateButtons();
        MessageBox.Show("Налаштування підключення збережено!", "Успіх");
    }

    private void btnCancelConn_Click(object sender, EventArgs e)
    {
        // Відкочуємо UI до значень з конфігу
        txtMssql.Text = _settings.Database.EncryptedMSSQL;
        txtSqlite.Text = _settings.Database.EncryptedSQLite;
        chkEncrypt.Checked = _settings.Security.UseEncryption;

        _dirtyConn = false;
        UpdateButtons();
    }

    // ================== TAB 2: MAPPING ==================

    private void RefreshMapsGrid()
    {
        dgvMaps.Rows.Clear();
        foreach (var map in _tempMappings)
        {
            dgvMaps.Rows.Add(
                map.Role,
                map.SourceTable,
                map.SourceVersionColumn ?? "-",
                string.IsNullOrWhiteSpace(map.FilterGroups) ? "-" : "Так",
                map.FullSync,
                $"{map.Fields.Count(f => f.IsUsed)} шт."
            );
            dgvMaps.Rows[dgvMaps.Rows.Count - 1].Tag = map;
        }
    }

    private void btnLoadJson_Click(object sender, EventArgs e)
    {
        if (_dirtyMap && MessageBox.Show("Є незбережені зміни. Завантаження файлу перезапише їх. Продовжити?", "Увага", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        using var ofd = new OpenFileDialog { Filter = "JSON (*.json)|*.json", Title = "Оберіть structure.json" };
        if (ofd.ShowDialog() != DialogResult.OK) return;

        List<OneCTableInfo> structure1C;
        try
        {
            var json = File.ReadAllText(ofd.FileName);
            structure1C = JsonSerializer.Deserialize<List<OneCTableInfo>>(json) ?? new();
        }
        catch (Exception ex) { MessageBox.Show("Помилка читання файлу: " + ex.Message); return; }

        // Очищаємо і заповнюємо _tempMappings
        _tempMappings.Clear();
        int count = 0;

        foreach (DataContextRole role in Enum.GetValues(typeof(DataContextRole)))
        {
            if (role == DataContextRole.None) continue;

            string name1C = GetOneCName(role);
            var found = structure1C.FirstOrDefault(x => x.Name.Equals(name1C, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                var newMap = new DataContextMap { Role = role, SourceTable = found.SQLTable, Description = "Auto-Loaded" };

                // Версія
                if (found.Fields.Values.Contains("_Version")) newMap.SourceVersionColumn = "_Version";
                else if (found.Fields.ContainsKey("Version")) newMap.SourceVersionColumn = found.Fields["Version"];
                else newMap.SourceVersionColumn = "0";

                // Поля
                foreach (var req in DataContextRequirements.GetRequiredFields(role))
                {
                    string src = FindColumnIn1C(req, found.Fields);
                    if (!string.IsNullOrEmpty(src))
                        newMap.Fields.Add(new FieldMap { TargetField = req, SourceColumn = src, IsUsed = true });
                }

                _tempMappings.Add(newMap);
                count++;
            }
        }

        RefreshMapsGrid();
        SetDirtyMap();
        MessageBox.Show($"Завантажено налаштування для {count} таблиць. Не забудьте натиснути 'Зберегти зміни'!", "Успіх");
    }

    private void btnEditMap_Click(object sender, EventArgs e)
    {
        if (dgvMaps.SelectedRows.Count == 0) return;
        var map = dgvMaps.SelectedRows[0].Tag as DataContextMap;
        if (map == null) return;

        using var frm = new MapEditForm(map);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            RefreshMapsGrid();
            SetDirtyMap();
        }
    }

    private void btnSaveMap_Click(object sender, EventArgs e)
    {
        // Записуємо зміни з _tempMappings в реальний конфіг
        _settings.Sync.Mappings = JsonSerializer.Deserialize<List<DataContextMap>>(JsonSerializer.Serialize(_tempMappings))!;
        ConfigManager.Save(_settings);

        _dirtyMap = false;
        UpdateButtons();
        MessageBox.Show("Структуру даних збережено!", "Успіх");
    }

    private void btnCancelMap_Click(object sender, EventArgs e)
    {
        // Відкочуємо _tempMappings назад до стану _settings
        CloneMappings();
        RefreshMapsGrid();
        _dirtyMap = false;
        UpdateButtons();
    }

    // ================== HELPERS ==================

    private string GetOneCName(DataContextRole role)
    {
        return role switch
        {
            DataContextRole.Номенклатура => "Справочник.Номенклатура",
            DataContextRole.Контрагенти => "Справочник.Контрагенты",
            DataContextRole.Магазини => "Справочник.Склады",
            DataContextRole.Працівники => "Справочник.СотрудникиОрганизации",
            DataContextRole.ОдиниціВиміру => "Справочник.ЕдиницыИзмерения",
            DataContextRole.Замовлення => "Документ.ВнутреннийЗаказ",
            DataContextRole.Специфікація => "Документ.Нива_СпецификацияНоменклатуры",
            DataContextRole.РегістрЦін => "РегистрСведений.ЦеныНоменклатуры",

            // Табличні частини
            DataContextRole.Замовлення_Товари => "Документ.ВнутреннийЗаказ.ТабличнаяЧасть.Товары",

            _ => ""
        };
    }

    private string FindColumnIn1C(string app, Dictionary<string, string> fields)
    {
        if (app == "Id" && fields.ContainsKey("Ref")) return fields["Ref"];
        if (app == "Name" && fields.ContainsKey("Description")) return fields["Description"];
        if (app == "ParentId" && fields.ContainsKey("Parent")) return fields["Parent"];
        if (app == "IsFolder" && fields.ContainsKey("IsFolder")) return fields["IsFolder"];
        if (app == "EDRPOU" && fields.ContainsKey("КодПоЕДРПОУ")) return fields["КодПоЕДРПОУ"];
        if (app == "DocumentId" && fields.ContainsKey("DocumentId")) return fields["DocumentId"];

        foreach (var kvp in fields)
        {
            string k = kvp.Key.ToLower();
            string a = app.ToLower();
            if (a == "price" && k.Contains("цена")) return kvp.Value;
            if (a == "sum" && k.Contains("сумма")) return kvp.Value;
            if (a == "quantity" && k.Contains("количество")) return kvp.Value;
            if ((a == "itemid" || a == "contractorid") && (k.Contains("номенклатура") || k.Contains("контрагент") || k == "ref")) return kvp.Value;
        }
        return "";
    }

    private void SettingsForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (_dirtyConn || _dirtyMap)
        {
            var res = MessageBox.Show("Є незбережені зміни! Ви впевнені, що хочете вийти без збереження?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No) e.Cancel = true;
        }
    }
}