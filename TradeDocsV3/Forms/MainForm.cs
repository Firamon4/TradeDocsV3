using System;
using System.Linq;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class MainForm : Form
{
    private readonly string _userName;
    private readonly string _userRole;
    private readonly AppSettings _settings;
    private readonly DocumentRepository _docRepo;

    public MainForm(string userName, string userRole, AppSettings settings)
    {
        InitializeComponent();
        _userName = userName;
        _userRole = userRole;
        _settings = settings;
        _docRepo = new DocumentRepository(_settings.Database.EncryptedSQLite);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        lblUserStatus.Text = $"👤 {_userName} ({_userRole})";
        LoadDocuments();
    }

    private void LoadDocuments()
    {
        dgvDocs.Rows.Clear();
        var docs = _docRepo.GetAll();
        foreach (var d in docs)
        {
            dgvDocs.Rows.Add(d.Id, d.Type, d.Number, d.Date, d.TotalSum, d.Status);
        }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        using var select = new SelectDocTypeForm();
        if (select.ShowDialog() == DialogResult.OK)
        {
            // Передаємо _settings у редактор
            using var frm = new DocumentEditorForm(_docRepo, _userName, _settings, null, select.SelectedType);
            frm.ShowDialog();
            LoadDocuments();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvDocs.SelectedRows.Count == 0) return;
        var id = dgvDocs.SelectedRows[0].Cells["colId"].Value.ToString();
        using var frm = new DocumentEditorForm(_docRepo, _userName, _settings, id);
        frm.ShowDialog();
        LoadDocuments();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvDocs.SelectedRows.Count == 0) return;
        var id = dgvDocs.SelectedRows[0].Cells["colId"].Value.ToString();
        if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            _docRepo.Delete(id);
            LoadDocuments();
        }
    }

    private void menuSettings_Click(object sender, EventArgs e)
    {
        using var frm = new SettingsForm(_settings);
        frm.ShowDialog();
    }

    private void menuSync_Click(object sender, EventArgs e)
    {
        // Завантажуємо чистий конфіг для синхронізації
        using var frm = new SyncForm(ConfigManager.Load());
        frm.ShowDialog();
    }


    private void menuUsers_Click(object sender, EventArgs e)
    {
        // Передаємо _settings, бо новий UserRepository вимагає саме його
        var repo = new UserRepository(_settings);
        using var frm = new UsersForm(repo);
        frm.ShowDialog();
    }

    private void menuService_Click(object sender, EventArgs e)
    {
        if (_userRole != "Admin") { MessageBox.Show("Тільки для адмінів."); return; }
        using var frm = new ServiceConfigForm();
        frm.ShowDialog();
    }

    private void menuExit_Click(object sender, EventArgs e) => Application.Exit();
}