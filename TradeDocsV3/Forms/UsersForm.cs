using System;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;

namespace TradeDocsV3.Forms;

public partial class UsersForm : Form
{
    private readonly UserRepository _repo;

    public UsersForm(UserRepository repo)
    {
        InitializeComponent();
        _repo = repo;
    }

    private void UsersForm_Load(object sender, EventArgs e) => RefreshGrid();

    private void RefreshGrid()
    {
        try { dgv.DataSource = _repo.GetAllUsers(); }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using var frm = new UserEditForm(new UserModel(), _repo);
        if (frm.ShowDialog() == DialogResult.OK) RefreshGrid();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) return;
        var user = (UserModel)dgv.SelectedRows[0].DataBoundItem;
        using var frm = new UserEditForm(user, _repo);
        if (frm.ShowDialog() == DialogResult.OK) RefreshGrid();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) return;
        var user = (UserModel)dgv.SelectedRows[0].DataBoundItem;
        if (user.Login == "admin") { MessageBox.Show("Не можна видалити Admin!"); return; }

        if (MessageBox.Show($"Видалити {user.Login}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            try { _repo.DeleteUser(user.Id); RefreshGrid(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}