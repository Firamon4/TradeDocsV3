using System;
using System.Windows.Forms;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class SettingsForm : Form
{
    private readonly AppSettings _settings;

    public SettingsForm(AppSettings settings)
    {
        InitializeComponent();
        _settings = settings;
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        txtMssql.Text = _settings.Database.EncryptedMSSQL;
        txtSqlite.Text = _settings.Database.EncryptedSQLite;
        RefreshGrid();
    }

    private void RefreshGrid()
    {
        dgvMaps.Rows.Clear();
        foreach (var map in _settings.Sync.Mappings)
        {
            dgvMaps.Rows.Add(map.Role, map.SourceTable, map.Description);
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var newMap = new DataContextMap();
        using var frm = new MapEditForm(newMap);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            _settings.Sync.Mappings.Add(newMap);
            RefreshGrid();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvMaps.SelectedRows.Count == 0) return;
        var map = _settings.Sync.Mappings[dgvMaps.SelectedRows[0].Index];
        using var frm = new MapEditForm(map);
        if (frm.ShowDialog() == DialogResult.OK) RefreshGrid();
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        if (dgvMaps.SelectedRows.Count == 0) return;
        _settings.Sync.Mappings.RemoveAt(dgvMaps.SelectedRows[0].Index);
        RefreshGrid();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        _settings.Database.EncryptedMSSQL = txtMssql.Text;
        _settings.Database.EncryptedSQLite = txtSqlite.Text;
        ConfigManager.Save(_settings);
        Close();
    }
}