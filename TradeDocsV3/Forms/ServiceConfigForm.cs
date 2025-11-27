using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class ServiceConfigForm : Form
{
    private readonly string _serviceDir;
    private readonly string _configPath;
    private ServiceConfigModel _config;

    public ServiceConfigForm(string serviceExePath)
    {
        InitializeComponent();
        _serviceDir = Path.GetDirectoryName(serviceExePath) ?? "";
        _configPath = Path.Combine(_serviceDir, "config.json");
        _config = new ServiceConfigModel();

        LoadConfig();
    }

    private void LoadConfig()
    {
        if (File.Exists(_configPath))
        {
            try
            {
                var json = File.ReadAllText(_configPath);
                _config = JsonSerializer.Deserialize<ServiceConfigModel>(json) ?? new ServiceConfigModel();
            }
            catch { MessageBox.Show("Помилка читання config.json"); }
        }

        // Розшифровуємо (використовуючи ключ зі служби!)
        txtSource.Text = ServiceEncryption.Decrypt(_config.Connections.SourceDb, _serviceDir);
        txtTarget.Text = ServiceEncryption.Decrypt(_config.Connections.TargetDb, _serviceDir);
        numInterval.Value = _config.SyncIntervalSeconds > 0 ? _config.SyncIntervalSeconds : 30;

        dgv.Rows.Clear();
        foreach (var t in _config.Tables)
        {
            dgv.Rows.Add(t.SourceTable, t.TargetTable, t.KeyColumn, t.VersionColumn, t.FullSync);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Збираємо дані
        _config.Connections.SourceDb = ServiceEncryption.Encrypt(txtSource.Text.Trim(), _serviceDir);
        _config.Connections.TargetDb = ServiceEncryption.Encrypt(txtTarget.Text.Trim(), _serviceDir);
        _config.SyncIntervalSeconds = (int)numInterval.Value;

        _config.Tables.Clear();
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (row.IsNewRow) continue;
            _config.Tables.Add(new ServiceConfigModel.TableItem
            {
                SourceTable = row.Cells[0].Value?.ToString() ?? "",
                TargetTable = row.Cells[1].Value?.ToString() ?? "",
                KeyColumn = row.Cells[2].Value?.ToString() ?? "",
                VersionColumn = row.Cells[3].Value?.ToString() ?? "",
                FullSync = Convert.ToBoolean(row.Cells[4].Value)
            });
        }

        try
        {
            var json = JsonSerializer.Serialize(_config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_configPath, json);

            // Питаємо про перезапуск
            if (MessageBox.Show("Конфігурацію збережено. Перезапустити службу для застосування змін?", "Перезапуск", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ServiceControllerHelper.StopService();
                ServiceControllerHelper.StartService();
            }
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Помилка збереження: " + ex.Message);
        }
    }
}