namespace TradeDocsV3.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuMain = new MenuStrip();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            pnlToolbar = new Panel();
            lblUserStatus = new Label();
            btnNew = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvDocs = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colNumber = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colSum = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            toolStripMenuItem4 = new ToolStripMenuItem();
            menuMain.SuspendLayout();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDocs).BeginInit();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.BackColor = Color.White;
            menuMain.Items.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem4, toolStripMenuItem1, toolStripMenuItem3 });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(900, 24);
            menuMain.TabIndex = 0;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(101, 20);
            toolStripMenuItem2.Text = "Налаштування";
            toolStripMenuItem2.Click += menuSettings_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(97, 20);
            toolStripMenuItem1.Text = "Синхронізація";
            toolStripMenuItem1.Click += menuSync_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(47, 20);
            toolStripMenuItem3.Text = "Вихід";
            toolStripMenuItem3.Click += menuExit_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(86, 20);
            toolStripMenuItem4.Text = "Користувачі";
            toolStripMenuItem4.Click += menuUsers_Click;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.WhiteSmoke;
            pnlToolbar.Controls.Add(lblUserStatus);
            pnlToolbar.Controls.Add(btnNew);
            pnlToolbar.Controls.Add(btnEdit);
            pnlToolbar.Controls.Add(btnDelete);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 24);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(900, 50);
            pnlToolbar.TabIndex = 1;
            // 
            // lblUserStatus
            // 
            lblUserStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserStatus.AutoSize = true;
            lblUserStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUserStatus.ForeColor = Color.DimGray;
            lblUserStatus.Location = new Point(725, 19);
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(54, 15);
            lblUserStatus.TabIndex = 0;
            lblUserStatus.Text = "User Info";
            lblUserStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.SeaGreen;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(10, 10);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(110, 30);
            btnNew.TabIndex = 1;
            btnNew.Text = "➕ Новий";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(130, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(110, 30);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Редагувати";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(250, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑 Видалити";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvDocs
            // 
            dgvDocs.AllowUserToAddRows = false;
            dgvDocs.AllowUserToResizeRows = false;
            dgvDocs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocs.BackgroundColor = Color.White;
            dgvDocs.BorderStyle = BorderStyle.None;
            dgvDocs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDocs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDocs.ColumnHeadersHeight = 40;
            dgvDocs.Columns.AddRange(new DataGridViewColumn[] { colId, colType, colNumber, colDate, colSum, colStatus });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDocs.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDocs.Dock = DockStyle.Fill;
            dgvDocs.EnableHeadersVisualStyles = false;
            dgvDocs.GridColor = Color.FromArgb(230, 230, 230);
            dgvDocs.Location = new Point(0, 74);
            dgvDocs.Name = "dgvDocs";
            dgvDocs.RowHeadersVisible = false;
            dgvDocs.RowTemplate.Height = 35;
            dgvDocs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocs.Size = new Size(900, 526);
            dgvDocs.TabIndex = 2;
            // 
            // colId
            // 
            colId.Name = "colId";
            colId.Visible = false;
            // 
            // colType
            // 
            colType.HeaderText = "Тип Документа";
            colType.Name = "colType";
            // 
            // colNumber
            // 
            colNumber.HeaderText = "Номер";
            colNumber.Name = "colNumber";
            // 
            // colDate
            // 
            colDate.HeaderText = "Дата Створення";
            colDate.Name = "colDate";
            // 
            // colSum
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            colSum.DefaultCellStyle = dataGridViewCellStyle2;
            colSum.HeaderText = "Сума (грн)";
            colSum.Name = "colSum";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Статус";
            colStatus.Name = "colStatus";
            // 
            // MainForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(dgvDocs);
            Controls.Add(pnlToolbar);
            Controls.Add(menuMain);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TradeDocs V3 - Головне Вікно";
            Load += MainForm_Load;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDocs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnNew, btnEdit, btnDelete;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId, colType, colNumber, colDate, colSum, colStatus;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
    }
}