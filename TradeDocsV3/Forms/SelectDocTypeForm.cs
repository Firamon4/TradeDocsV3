using System;
using System.Windows.Forms;

namespace TradeDocsV3.Forms;

public partial class SelectDocTypeForm : Form
{
    public string SelectedType { get; set; } = "Order";

    public SelectDocTypeForm()
    {
        InitializeComponent();
    }

    private void btnOrder_Click(object sender, EventArgs e)
    {
        SelectedType = "Order";
        DialogResult = DialogResult.OK;
    }

    private void btnReturn_Click(object sender, EventArgs e)
    {
        SelectedType = "Return";
        DialogResult = DialogResult.OK;
    }
}