namespace TradeDocsV3.Forms
{
    partial class MapEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            cmbRole.FormattingEnabled = true;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colUse, colField, colSource });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle2;
            dgv.Location = new Point(10, 55);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.Size = new Size(380, 185);
            dgv.TabIndex = 2;
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
            btnAddField.TabIndex = 0;
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
            btnDeleteField.TabIndex = 1;
            btnDeleteField.Text = "🗑 Видалити";
            btnDeleteField.UseVisualStyleBackColor = false;
            btnDeleteField.Click += btnDeleteField_Click;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.SeaGreen;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(200, 450);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 30);
            btnOk.TabIndex = 6;
            btnOk.Text = "Зберегти";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(310, 450);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // MapEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 500);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(grpMap);
            Controls.Add(grpSource);
            Controls.Add(txtDesc);
            Controls.Add(lblDesc);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
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
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.TextBox txtVer;
        private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colField;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnDeleteField;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}