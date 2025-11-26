using System;
using System.Linq;
using System.Windows.Forms;
using TradeDocsV3.Models;

namespace TradeDocsV3.Forms;

public partial class SelectRoleForm : Form
{
    public DataContextRole SelectedRole { get; private set; } = DataContextRole.None;

    public SelectRoleForm()
    {
        InitializeComponent();
    }

    private void SelectRoleForm_Load(object sender, EventArgs e)
    {
        // Завантажуємо Типи (крім Невизначено)
        var types = Enum.GetValues(typeof(DataContextType))
                        .Cast<DataContextType>()
                        .Where(t => t != DataContextType.Невизначено)
                        .ToList();

        cmbType.DataSource = types;
        cmbType.SelectedIndex = -1;

        // Поки тип не вибрано, ролі заблоковані
        cmbRole.Enabled = false;
        btnNext.Enabled = false;
    }

    private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbType.SelectedItem is DataContextType selectedType)
        {
            // Фільтруємо ролі, які відповідають цьому типу
            var allRoles = Enum.GetValues(typeof(DataContextRole)).Cast<DataContextRole>();

            var filteredRoles = allRoles.Where(r =>
                r != DataContextRole.None &&
                DataContextRequirements.GetType(r) == selectedType
            ).ToList();

            cmbRole.DataSource = filteredRoles;
            cmbRole.Enabled = true;

            if (filteredRoles.Count > 0)
                cmbRole.SelectedIndex = 0;
            else
                cmbRole.SelectedIndex = -1;
        }
    }

    private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnNext.Enabled = cmbRole.SelectedItem != null;
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        if (cmbRole.SelectedItem is DataContextRole role)
        {
            SelectedRole = role;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}