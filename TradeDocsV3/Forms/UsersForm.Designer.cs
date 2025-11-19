namespace TradeDocsV3.Forms
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLast = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // Panel
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 50;
            this.pnlTop.Controls.Add(this.btnAdd); this.pnlTop.Controls.Add(this.btnEdit); this.pnlTop.Controls.Add(this.btnDelete);

            // Buttons
            this.btnAdd.Text = "➕ Додати"; this.btnAdd.Location = new System.Drawing.Point(10, 10); this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "✎ Змінити"; this.btnEdit.Location = new System.Drawing.Point(120, 10); this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "🗑 Видалити"; this.btnDelete.Location = new System.Drawing.Point(230, 10); this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Grid
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.AllowUserToAddRows = false; this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colLogin, this.colRole, this.colActive, this.colCreated, this.colLast });

            this.colLogin.HeaderText = "Логін"; this.colLogin.DataPropertyName = "Login";
            this.colRole.HeaderText = "Роль"; this.colRole.DataPropertyName = "Role";
            this.colActive.HeaderText = "Актив"; this.colActive.DataPropertyName = "IsActive";
            this.colCreated.HeaderText = "Створено"; this.colCreated.DataPropertyName = "CreatedAt"; this.colCreated.Width = 120;
            this.colLast.HeaderText = "Останній вхід"; this.colLast.DataPropertyName = "LastLoginAt"; this.colLast.Width = 120;

            // Form
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.dgv); this.Controls.Add(this.pnlTop);
            this.Text = "Користувачі";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UsersForm_Load);

            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDelete;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogin, colRole, colCreated, colLast;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
    }
}