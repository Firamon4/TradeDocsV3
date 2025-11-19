using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;

namespace TradeDocsV3.Forms;

public partial class DocumentEditorForm : Form
{
    private readonly DocumentRepository _repo;
    private readonly string _user;
    private readonly AppSettings _settings;
    private readonly string _docId;
    private readonly string _type;
    private readonly List<DocumentItemModel> _items = new();
    private List<Product> _products = new();

    public DocumentEditorForm(DocumentRepository repo, string user, AppSettings settings, string? docId = null, string? type = null)
    {
        InitializeComponent();
        _repo = repo;
        _user = user;
        _settings = settings;
        _docId = docId;
        _type = type ?? "Order";

        treeNomenclature.AfterSelect += (s, e) => FilterList(e.Node.Tag?.ToString());
        listNomenclature.DoubleClick += (s, e) => btnAddItem.PerformClick();
    }

    private async void DocumentEditorForm_Load(object sender, EventArgs e)
    {
        // Якщо це редагування існуючого - завантажимо його (логіка пропущена для стислості)
        txtNumber.Text = _docId ?? "Новий";

        // Завантажуємо каталог
        await LoadCatalog(DataContextRole.Nomenclature);
    }

    private async Task LoadCatalog(DataContextRole role)
    {
        var map = _settings.Sync.Mappings.FirstOrDefault(m => m.Role == role);
        if (map == null) { MessageBox.Show($"Немає маппінгу для {role}"); return; }

        var tableName = DataContextRequirements.GetTargetTableName(role);

        // Знаходимо потрібні поля у списку Fields
        // Нам треба знайти, як називаються колонки в SQLite (TargetField) для Id, Name тощо.
        // В нашому дизайні TargetField для 'Id' завжди 'Id', але перевіримо, чи вони 'IsUsed'.

        var fId = map.Fields.FirstOrDefault(f => f.TargetField == "Id" && f.IsUsed);
        var fName = map.Fields.FirstOrDefault(f => f.TargetField == "Name" && f.IsUsed);
        var fParent = map.Fields.FirstOrDefault(f => f.TargetField == "ParentId" && f.IsUsed);
        var fFolder = map.Fields.FirstOrDefault(f => f.TargetField == "IsFolder" && f.IsUsed);

        if (fId == null || fName == null)
        {
            MessageBox.Show("Помилка: Поля Id та Name обов'язкові і мають бути активними (галочка Вкл).");
            return;
        }

        // Будуємо запит до SQLite
        // Беремо ТІЛЬКИ ті поля, які увімкнені
        var sql = $"SELECT {fId.TargetField}, {fName.TargetField}";

        if (fParent != null) sql += $", {fParent.TargetField}"; else sql += ", NULL";
        if (fFolder != null) sql += $", {fFolder.TargetField}"; else sql += ", 0";

        sql += $" FROM {tableName}";

        try
        {
            using var conn = new SqliteConnection(_settings.Database.EncryptedSQLite);
            await conn.OpenAsync();
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                _products.Add(new Product
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    ParentId = reader.IsDBNull(2) ? null : reader.GetString(2),
                    IsFolder = reader.GetInt32(3) == 1
                });
            }
            BuildTree();
        }
        catch (Exception ex) { MessageBox.Show("Помилка завантаження каталогу: " + ex.Message); }
    }

    private void BuildTree()
    {
        treeNomenclature.Nodes.Clear();
        var roots = _products.Where(p => p.ParentId == null && p.IsFolder).OrderBy(p => p.Name);
        foreach (var p in roots)
        {
            var node = treeNomenclature.Nodes.Add(p.Name);
            node.Tag = p.Id;
            AddChildren(node, p.Id);
        }
    }

    private void AddChildren(TreeNode parentNode, string parentId)
    {
        var children = _products.Where(p => p.ParentId == parentId && p.IsFolder).OrderBy(p => p.Name);
        foreach (var p in children)
        {
            var node = parentNode.Nodes.Add(p.Name);
            node.Tag = p.Id;
            AddChildren(node, p.Id);
        }
    }

    private void FilterList(string? parentId)
    {
        listNomenclature.DataSource = _products
            .Where(p => !p.IsFolder && (parentId == null || p.ParentId == parentId))
            .OrderBy(p => p.Name).ToList();
        listNomenclature.DisplayMember = "Name";
    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        if (listNomenclature.SelectedItem is not Product p) return;
        _items.Add(new DocumentItemModel { ItemName = p.Name, Quantity = 1, Price = 100 });
        RefreshGrid();
    }

    private void RefreshGrid()
    {
        dgvItems.Rows.Clear();
        foreach (var i in _items) dgvItems.Rows.Add(i.ItemName, i.Quantity, i.Price, i.Sum);
        lblTotal.Text = $"{_items.Sum(x => x.Sum):0.00} грн";
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var doc = new DocumentModel { CreatedBy = _user, Type = _type, Number = txtNumber.Text, TotalSum = _items.Sum(x => x.Sum) };
        _repo.Save(doc, _items);
        Close();
    }
}