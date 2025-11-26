using System;
using System.Linq;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class SettingsForm : Form
{
    private readonly AppSettings _settings;
    private readonly UserRepository _userRepo;
    private bool _isDirty = false;

    public SettingsForm(AppSettings settings)
    {
        InitializeComponent();
        _settings = settings;
        _userRepo = new UserRepository(_settings);
        this.FormClosing += SettingsForm_FormClosing;
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        txtMssql.Text = _settings.Database.EncryptedMSSQL;
        txtSqlite.Text = _settings.Database.EncryptedSQLite;
        chkEncrypt.Checked = _settings.Security.UseEncryption;

        RefreshMaps();
        RefreshUsers();

        txtMssql.TextChanged += (s, a) => SetDirty();
        txtSqlite.TextChanged += (s, a) => SetDirty();
        chkEncrypt.CheckedChanged += (s, a) => SetDirty();

        _isDirty = false;
        UpdateSaveButton();

        // Додаткова страховка: виносимо панель кнопок на передній план
        pnlBottom.BringToFront();
    }

    private void SetDirty()
    {
        _isDirty = true;
        UpdateSaveButton();
    }

    private void UpdateSaveButton()
    {
        btnSave.Text = _isDirty ? "💾 Зберегти *" : "💾 Зберегти";
    }

    private void SettingsForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (_isDirty)
        {
            var result = MessageBox.Show("У вас є незбережені зміни. Зберегти їх перед виходом?", "Увага", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) SaveSettings();
            else if (result == DialogResult.Cancel) e.Cancel = true;
        }
    }

    // --- MAPS ---

    private void RefreshMaps()
    {
        dgvMaps.Rows.Clear();
        foreach (var map in _settings.Sync.Mappings)
        {
            // УВАГА: Порядок аргументів має співпадати з порядком колонок в Designer.cs
            dgvMaps.Rows.Add(
                map.Role,                                       // 0. Role
                map.SourceTable,                                // 1. Table
                map.SourceVersionColumn ?? "(немає)",           // 2. Ver
                string.IsNullOrWhiteSpace(map.FilterGroups) ? "-" : "Так", // 3. Filter
                map.FullSync,                                   // 4. Full (CheckBox) -> передаємо bool
                $"{map.Fields.Count(f => f.IsUsed)} шт.",       // 5. Count (Text) -> передаємо string
                map.Description                                 // 6. Desc
            );
        }
    }

    private void btnAddMap_Click(object sender, EventArgs e)
    {
        using var roleForm = new SelectRoleForm();
        if (roleForm.ShowDialog() != DialogResult.OK) return;

        var newMap = new DataContextMap { Role = roleForm.SelectedRole };
        using var frm = new MapEditForm(newMap);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            _settings.Sync.Mappings.Add(newMap);
            RefreshMaps();
            SetDirty();
        }
    }

    private void btnEditMap_Click(object sender, EventArgs e)
    {
        if (dgvMaps.SelectedRows.Count == 0) return;
        var map = _settings.Sync.Mappings[dgvMaps.SelectedRows[0].Index];
        using var frm = new MapEditForm(map);
        if (frm.ShowDialog() == DialogResult.OK) { RefreshMaps(); SetDirty(); }
    }

    private void btnDelMap_Click(object sender, EventArgs e)
    {
        if (dgvMaps.SelectedRows.Count == 0) return;
        _settings.Sync.Mappings.RemoveAt(dgvMaps.SelectedRows[0].Index);
        RefreshMaps();
        SetDirty();
    }

    // --- USERS ---

    private void RefreshUsers()
    {
        try { dgvUsers.DataSource = _userRepo.GetAllUsers(); } catch { }
    }

    private void btnAddUser_Click(object sender, EventArgs e)
    {
        var newUser = new UserModel();
        using var frm = new UserEditForm(newUser, _userRepo);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            try { _userRepo.SaveUser(newUser); RefreshUsers(); }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }
    }

    private void btnEditUser_Click(object sender, EventArgs e)
    {
        if (dgvUsers.SelectedRows.Count == 0) return;
        var user = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;
        using var frm = new UserEditForm(user, _userRepo);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            try { _userRepo.SaveUser(user); RefreshUsers(); }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }
    }

    private void btnDelUser_Click(object sender, EventArgs e)
    {
        if (dgvUsers.SelectedRows.Count == 0) return;
        var user = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;
        if (user.Login.ToLower() == "admin") { MessageBox.Show("Адміна видаляти не можна!"); return; }

        if (MessageBox.Show($"Видалити {user.Login}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            try { _userRepo.DeleteUser(user.Id); RefreshUsers(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    // --- MAIN ---

    private void SaveSettings()
    {
        _settings.Database.EncryptedMSSQL = txtMssql.Text.Trim();
        _settings.Database.EncryptedSQLite = txtSqlite.Text.Trim();
        _settings.Security.UseEncryption = chkEncrypt.Checked;

        ConfigManager.Save(_settings);
        try { _userRepo.EnsureMssqlTables(); } catch { }

        _isDirty = false;
        UpdateSaveButton();
        MessageBox.Show("Збережено!");
        Close();
    }

    private void btnSave_Click(object sender, EventArgs e) => SaveSettings();
    private void btnCancel_Click(object sender, EventArgs e) => Close();
}