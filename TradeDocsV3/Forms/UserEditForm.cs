using System;
using System.Linq;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;
using Microsoft.VisualBasic; // Потрібно для InputBox

namespace TradeDocsV3.Forms;

public partial class UserEditForm : Form
{
    private readonly UserModel _user;
    private readonly UserRepository _repo;

    public UserEditForm(UserModel user, UserRepository repo)
    {
        InitializeComponent();
        _user = user;
        _repo = repo;
    }

    private void UserEditForm_Load(object sender, EventArgs e)
    {
        LoadRoles();
        txtL.Text = _user.Login;
        chkA.Checked = _user.IsActive;
        if (cmbR.Items.Contains(_user.Role)) cmbR.SelectedItem = _user.Role;
    }

    private void LoadRoles()
    {
        cmbR.Items.Clear();
        cmbR.Items.AddRange(_repo.GetRoles().ToArray());
    }

    private void btnAddRole_Click(object sender, EventArgs e)
    {
        string r = Interaction.InputBox("Назва нової ролі:", "Нова роль");
        if (!string.IsNullOrWhiteSpace(r))
        {
            _repo.AddRole(r);
            LoadRoles();
            cmbR.SelectedItem = r;
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtL.Text)) { MessageBox.Show("Login empty!"); return; }
        if (cmbR.SelectedItem == null) { MessageBox.Show("Role empty!"); return; }

        _user.Login = txtL.Text;
        _user.Role = cmbR.SelectedItem.ToString();
        _user.IsActive = chkA.Checked;
        _user.NewPassword = string.IsNullOrWhiteSpace(txtP.Text) ? null : txtP.Text;

        try { _repo.SaveUser(_user); DialogResult = DialogResult.OK; Close(); }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnCancel_Click(object sender, EventArgs e) { Close(); }
}