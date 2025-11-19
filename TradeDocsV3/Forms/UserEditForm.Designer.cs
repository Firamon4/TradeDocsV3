namespace TradeDocsV3.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblL = new System.Windows.Forms.Label();
            this.txtL = new System.Windows.Forms.TextBox();
            this.lblP = new System.Windows.Forms.Label();
            this.txtP = new System.Windows.Forms.TextBox();
            this.lblR = new System.Windows.Forms.Label();
            this.cmbR = new System.Windows.Forms.ComboBox();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.chkA = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Controls
            this.lblL.Text = "Логін:"; this.lblL.Location = new System.Drawing.Point(20, 20); this.lblL.AutoSize = true;
            this.txtL.Location = new System.Drawing.Point(20, 40); this.txtL.Size = new System.Drawing.Size(240, 23);

            this.lblP.Text = "Новий пароль:"; this.lblP.Location = new System.Drawing.Point(20, 80); this.lblP.AutoSize = true;
            this.txtP.Location = new System.Drawing.Point(20, 100); this.txtP.Size = new System.Drawing.Size(240, 23); this.txtP.UseSystemPasswordChar = true;

            this.lblR.Text = "Роль:"; this.lblR.Location = new System.Drawing.Point(20, 140); this.lblR.AutoSize = true;
            this.cmbR.Location = new System.Drawing.Point(20, 160); this.cmbR.Size = new System.Drawing.Size(190, 23); this.cmbR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnAddRole.Text = "+"; this.btnAddRole.Location = new System.Drawing.Point(215, 159); this.btnAddRole.Size = new System.Drawing.Size(45, 25);
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);

            this.chkA.Text = "Активний"; this.chkA.Location = new System.Drawing.Point(20, 200); this.chkA.AutoSize = true;

            // Buttons
            this.btnOk.Text = "Зберегти"; this.btnOk.Location = new System.Drawing.Point(50, 240); this.btnOk.Size = new System.Drawing.Size(90, 30);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            this.btnCancel.Text = "Відміна"; this.btnCancel.Location = new System.Drawing.Point(150, 240); this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(280, 300);
            this.Controls.Add(this.lblL); this.Controls.Add(this.txtL);
            this.Controls.Add(this.lblP); this.Controls.Add(this.txtP);
            this.Controls.Add(this.lblR); this.Controls.Add(this.cmbR); this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.chkA);
            this.Controls.Add(this.btnOk); this.Controls.Add(this.btnCancel);
            this.Text = "Користувач";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UserEditForm_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }
        private System.Windows.Forms.Label lblL, lblP, lblR;
        private System.Windows.Forms.TextBox txtL, txtP;
        private System.Windows.Forms.ComboBox cmbR;
        private System.Windows.Forms.CheckBox chkA;
        private System.Windows.Forms.Button btnOk, btnCancel, btnAddRole;
    }
}