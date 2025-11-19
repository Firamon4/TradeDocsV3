using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TradeDocsV3.Models;

namespace TradeDocsV3.Forms;

public partial class MapEditForm : Form
{
    private readonly DataContextMap _map;

    public MapEditForm(DataContextMap mapToEdit)
    {
        InitializeComponent();
        _map = mapToEdit;
    }

    private void MapEditForm_Load(object sender, EventArgs e)
    {
        cmbRole.DataSource = Enum.GetValues(typeof(DataContextRole));
        cmbRole.SelectedItem = _map.Role;
        txtDesc.Text = _map.Description;
        txtTable.Text = _map.SourceTable;
        txtVer.Text = _map.SourceVersionColumn;
        PopulateGrid();
    }

    private void cmbRole_SelectedIndexChanged(object sender, EventArgs e) => PopulateGrid();

    private void PopulateGrid()
    {
        dgv.Rows.Clear();
        var role = (DataContextRole)cmbRole.SelectedItem;
        var requiredFields = DataContextRequirements.GetRequiredFields(role);

        // 1. Додаємо збережені поля
        foreach (var fieldMap in _map.Fields)
        {
            bool isRequired = requiredFields.Contains(fieldMap.TargetField);
            AddGridRow(fieldMap.IsUsed, fieldMap.TargetField, fieldMap.SourceColumn, isRequired);
        }

        // 2. Додаємо обов'язкові, якщо їх не було
        foreach (var reqField in requiredFields)
        {
            if (!_map.Fields.Any(f => f.TargetField == reqField))
            {
                AddGridRow(true, reqField, "", true);
            }
        }
    }

    private void AddGridRow(bool isUsed, string targetField, string sourceCol, bool isReadOnlyName)
    {
        int idx = dgv.Rows.Add(isUsed, targetField, sourceCol);
        dgv.Rows[idx].Cells[1].ReadOnly = isReadOnlyName;
        if (isReadOnlyName)
        {
            dgv.Rows[idx].Cells[1].Style.BackColor = System.Drawing.Color.WhiteSmoke;
            dgv.Rows[idx].Cells[1].Style.ForeColor = System.Drawing.Color.Gray;
        }
    }

    private void btnAddField_Click(object sender, EventArgs e)
    {
        // Додаємо рядок, який можна редагувати
        AddGridRow(true, "", "", false);
    }

    private void btnDeleteField_Click(object sender, EventArgs e)
    {
        if (dgv.SelectedRows.Count > 0)
        {
            var row = dgv.SelectedRows[0];
            // Перевіряємо, чи є це поле обов'язковим (ReadOnly = true)
            if (row.Cells[1].ReadOnly)
            {
                MessageBox.Show("Це обов'язкове системне поле. Його не можна видалити, але можна вимкнути (зняти галочку), хоча це не рекомендовано.", "Заборонено");
                return;
            }
            dgv.Rows.Remove(row);
        }
        else if (dgv.CurrentCell != null)
        {
            var row = dgv.Rows[dgv.CurrentCell.RowIndex];
            if (row.Cells[1].ReadOnly)
            {
                MessageBox.Show("Це обов'язкове системне поле.", "Заборонено");
                return;
            }
            dgv.Rows.Remove(row);
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if ((DataContextRole)cmbRole.SelectedItem == DataContextRole.None) { MessageBox.Show("Оберіть роль!"); return; }

        _map.Role = (DataContextRole)cmbRole.SelectedItem;
        _map.Description = txtDesc.Text;
        _map.SourceTable = txtTable.Text;
        _map.SourceVersionColumn = txtVer.Text;

        _map.Fields.Clear();

        foreach (DataGridViewRow row in dgv.Rows)
        {
            // Важливо: Використовуємо безпечне зчитування, щоб уникнути NullReference
            bool isUsed = Convert.ToBoolean(row.Cells[0].Value);
            string target = row.Cells[1].Value?.ToString()?.Trim() ?? "";
            string source = row.Cells[2].Value?.ToString()?.Trim() ?? "";

            if (!string.IsNullOrEmpty(target))
            {
                if (isUsed && string.IsNullOrEmpty(source))
                {
                    MessageBox.Show($"Вкажіть колонку 1С для поля '{target}'!", "Увага");
                    return;
                }
                _map.Fields.Add(new FieldMap { IsUsed = isUsed, TargetField = target, SourceColumn = source });
            }
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
}