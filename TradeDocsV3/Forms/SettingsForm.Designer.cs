namespace TradeDocsV3.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlConn = new Panel();
            grpConn = new GroupBox();
            label1 = new Label();
            txtMssql = new TextBox();
            label2 = new Label();
            txtSqlite = new TextBox();
            pnlMap = new Panel();
            grpMap = new GroupBox();
            dgvMaps = new DataGridView();
            colRole = new DataGridViewTextBoxColumn();
            colTable = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            pnlActions = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDel = new Button();
            pnlBottom = new Panel();
            btnSave = new Button();
            pnlTop.SuspendLayout();
            pnlConn.SuspendLayout();
            grpConn.SuspendLayout();
            pnlMap.SuspendLayout();
            grpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaps).BeginInit();
            pnlActions.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(500, 50);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Налаштування системи";
            // 
            // pnlConn
            // 
            pnlConn.Controls.Add(grpConn);
            pnlConn.Dock = DockStyle.Top;
            pnlConn.Location = new Point(0, 50);
            pnlConn.Name = "pnlConn";
            pnlConn.Padding = new Padding(10);
            pnlConn.Size = new Size(500, 100);
            pnlConn.TabIndex = 1;
            // 
            // grpConn
            // 
            grpConn.Controls.Add(label1);
            grpConn.Controls.Add(txtMssql);
            grpConn.Controls.Add(label2);
            grpConn.Controls.Add(txtSqlite);
            grpConn.Dock = DockStyle.Fill;
            grpConn.Location = new Point(10, 10);
            grpConn.Name = "grpConn";
            grpConn.Size = new Size(480, 80);
            grpConn.TabIndex = 0;
            grpConn.TabStop = false;
            grpConn.Text = "Підключення до Баз Даних";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(15, 25);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "MSSQL (1C):";
            // 
            // txtMssql
            // 
            txtMssql.Location = new Point(100, 22);
            txtMssql.Name = "txtMssql";
            txtMssql.Size = new Size(350, 23);
            txtMssql.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(15, 55);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "SQLite (Local):";
            // 
            // txtSqlite
            // 
            txtSqlite.Location = new Point(100, 52);
            txtSqlite.Name = "txtSqlite";
            txtSqlite.Size = new Size(350, 23);
            txtSqlite.TabIndex = 3;
            // 
            // pnlMap
            // 
            pnlMap.Controls.Add(grpMap);
            pnlMap.Dock = DockStyle.Fill;
            pnlMap.Location = new Point(0, 150);
            pnlMap.Name = "pnlMap";
            pnlMap.Padding = new Padding(10);
            pnlMap.Size = new Size(500, 350);
            pnlMap.TabIndex = 0;
            // 
            // grpMap
            // 
            grpMap.Controls.Add(dgvMaps);
            grpMap.Controls.Add(pnlActions);
            grpMap.Dock = DockStyle.Fill;
            grpMap.Location = new Point(10, 10);
            grpMap.Name = "grpMap";
            grpMap.Size = new Size(480, 330);
            grpMap.TabIndex = 0;
            grpMap.TabStop = false;
            grpMap.Text = "Маппінг Даних (Ролі таблиць)";
            // 
            // dgvMaps
            // 
            dgvMaps.AllowUserToAddRows = false;
            dgvMaps.BackgroundColor = Color.White;
            dgvMaps.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F);
            dgvMaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaps.Columns.AddRange(new DataGridViewColumn[] { colRole, colTable, colDesc });
            dgvMaps.Dock = DockStyle.Fill;
            dgvMaps.EnableHeadersVisualStyles = false;
            dgvMaps.Location = new Point(3, 19);
            dgvMaps.Name = "dgvMaps";
            dgvMaps.RowHeadersVisible = false;
            dgvMaps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaps.Size = new Size(474, 268);
            dgvMaps.TabIndex = 0;
            // 
            // colRole
            // 
            colRole.HeaderText = "Роль";
            colRole.Name = "colRole";
            colRole.Width = 120;
            // 
            // colTable
            // 
            colTable.HeaderText = "Таблиця 1С";
            colTable.Name = "colTable";
            colTable.Width = 150;
            // 
            // colDesc
            // 
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.HeaderText = "Опис";
            colDesc.Name = "colDesc";
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(3, 287);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(474, 40);
            pnlActions.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(5, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Додати";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(90, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✎ Змінити";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.IndianRed;
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.ForeColor = Color.White;
            btnDel.Location = new Point(175, 5);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(80, 30);
            btnDel.TabIndex = 2;
            btnDel.Text = "🗑 Видалити";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.WhiteSmoke;
            pnlBottom.Controls.Add(btnSave);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 500);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(500, 50);
            pnlBottom.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.Dock = DockStyle.Right;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(500, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "💾 ЗБЕРЕГТИ НАЛАШТУВАННЯ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(500, 550);
            Controls.Add(pnlMap);
            Controls.Add(pnlConn);
            Controls.Add(pnlTop);
            Controls.Add(pnlBottom);
            Font = new Font("Segoe UI", 9F);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Налаштування";
            Load += SettingsForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlConn.ResumeLayout(false);
            grpConn.ResumeLayout(false);
            grpConn.PerformLayout();
            pnlMap.ResumeLayout(false);
            grpMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaps).EndInit();
            pnlActions.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop, pnlConn, pnlMap, pnlBottom, pnlActions;
        private System.Windows.Forms.Label lblTitle, label1, label2;
        private System.Windows.Forms.GroupBox grpConn, grpMap;
        private System.Windows.Forms.TextBox txtMssql, txtSqlite;
        private System.Windows.Forms.DataGridView dgvMaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole, colTable, colDesc;
        private System.Windows.Forms.Button btnAdd, btnEdit, btnDel, btnSave;
    }
}