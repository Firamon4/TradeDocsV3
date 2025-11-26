namespace TradeDocsV3.Forms
{
    partial class MapEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblDesc = new Label();
            txtDesc = new TextBox();
            grpSource = new GroupBox();
            lblTable = new Label();
            txtTable = new TextBox();
            lblVer = new Label();
            txtVer = new TextBox();
            grpMap = new GroupBox();
            dgv = new DataGridView();
            colUse = new DataGridViewCheckBoxColumn();
            colField = new DataGridViewTextBoxColumn();
            colSource = new DataGridViewTextBoxColumn();
            btnAddField = new Button();
            btnDeleteField = new Button();
            btnOk = new Button();
            btnCancel = new Button();
            lblFilter = new Label();
            txtFilter = new TextBox();
            chkFullSync = new CheckBox();
            grpSource.SuspendLayout();
            grpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 23);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(71, 15);
            lblRole.TabIndex = 0;
            lblRole.Text = "Роль даних:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location = new Point(100, 20);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(280, 23);
            cmbRole.TabIndex = 1;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Location = new Point(20, 53);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(39, 15);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "Опис:";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(100, 50);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(280, 23);
            txtDesc.TabIndex = 3;
            // 
            // grpSource
            // 
            grpSource.Controls.Add(lblTable);
            grpSource.Controls.Add(txtTable);
            grpSource.Controls.Add(lblVer);
            grpSource.Controls.Add(txtVer);
            grpSource.Location = new Point(20, 90);
            grpSource.Name = "grpSource";
            grpSource.Size = new Size(360, 90);
            grpSource.TabIndex = 4;
            grpSource.TabStop = false;
            grpSource.Text = "Джерело 1С";
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Location = new Point(15, 28);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(57, 15);
            lblTable.TabIndex = 0;
            lblTable.Text = "Таблиця:";
            // 
            // txtTable
            // 
            txtTable.Location = new Point(80, 25);
            txtTable.Name = "txtTable";
            txtTable.Size = new Size(260, 23);
            txtTable.TabIndex = 1;
            // 
            // lblVer
            // 
            lblVer.AutoSize = true;
            lblVer.Location = new Point(15, 58);
            lblVer.Name = "lblVer";
            lblVer.Size = new Size(45, 15);
            lblVer.TabIndex = 2;
            lblVer.Text = "Версія:";
            // 
            // txtVer
            // 
            txtVer.Location = new Point(80, 55);
            txtVer.Name = "txtVer";
            txtVer.Size = new Size(260, 23);
            txtVer.TabIndex = 3;
            // 
            // grpMap
            // 
            grpMap.Controls.Add(dgv);
            grpMap.Controls.Add(btnAddField);
            grpMap.Controls.Add(btnDeleteField);
            grpMap.Location = new Point(20, 190);
            grpMap.Name = "grpMap";
            grpMap.Size = new Size(400, 250);
            grpMap.TabIndex = 5;
            grpMap.TabStop = false;
            grpMap.Text = "Поля та Колонки";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colUse, colField, colSource });
            dgv.Location = new Point(10, 55);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.Size = new Size(380, 185);
            dgv.TabIndex = 0;
            // 
            // colUse
            // 
            colUse.HeaderText = "Вкл";
            colUse.Name = "colUse";
            colUse.Width = 40;
            // 
            // colField
            // 
            colField.HeaderText = "Поле (App)";
            colField.Name = "colField";
            colField.ReadOnly = true;
            colField.Width = 150;
            // 
            // colSource
            // 
            colSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSource.HeaderText = "Колонка (1C)";
            colSource.Name = "colSource";
            // 
            // btnAddField
            // 
            btnAddField.BackColor = Color.WhiteSmoke;
            btnAddField.FlatStyle = FlatStyle.Flat;
            btnAddField.Location = new Point(10, 22);
            btnAddField.Name = "btnAddField";
            btnAddField.Size = new Size(120, 25);
            btnAddField.TabIndex = 1;
            btnAddField.Text = "➕ Додати поле";
            btnAddField.UseVisualStyleBackColor = false;
            btnAddField.Click += btnAddField_Click;
            // 
            // btnDeleteField
            // 
            btnDeleteField.BackColor = Color.WhiteSmoke;
            btnDeleteField.FlatStyle = FlatStyle.Flat;
            btnDeleteField.Location = new Point(140, 22);
            btnDeleteField.Name = "btnDeleteField";
            btnDeleteField.Size = new Size(120, 25);
            btnDeleteField.TabIndex = 2;
            btnDeleteField.Text = "🗑 Видалити";
            btnDeleteField.UseVisualStyleBackColor = false;
            btnDeleteField.Click += btnDeleteField_Click;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.SeaGreen;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(200, 540);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 30);
            btnOk.TabIndex = 9;
            btnOk.Text = "Зберегти";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(310, 540);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(20, 450);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(204, 15);
            lblFilter.TabIndex = 6;
            lblFilter.Text = "Фільтр груп (ID батьків через кому):";
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(20, 470);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(400, 23);
            txtFilter.TabIndex = 7;
            // 
            // chkFullSync
            // 
            chkFullSync.AutoSize = true;
            chkFullSync.ForeColor = Color.Black;
            chkFullSync.Location = new Point(20, 500);
            chkFullSync.Name = "chkFullSync";
            chkFullSync.Size = new Size(378, 19);
            chkFullSync.TabIndex = 8;
            chkFullSync.Text = "Повна синхронізація (Очищати таблицю перед завантаженням)";
            // 
            // MapEditForm
            // 
            ClientSize = new Size(440, 590);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(lblDesc);
            Controls.Add(txtDesc);
            Controls.Add(grpSource);
            Controls.Add(grpMap);
            Controls.Add(lblFilter);
            Controls.Add(txtFilter);
            Controls.Add(chkFullSync);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MapEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редагування правила";
            Load += MapEditForm_Load;
            grpSource.ResumeLayout(false);
            grpSource.PerformLayout();
            grpMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblRole, lblDesc, lblTable, lblVer, lblFilter;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtDesc, txtTable, txtVer, txtFilter;
        private System.Windows.Forms.CheckBox chkFullSync;
        private System.Windows.Forms.GroupBox grpSource, grpMap;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colField, colSource;
        private System.Windows.Forms.Button btnAddField, btnDeleteField, btnOk, btnCancel;
    }
}