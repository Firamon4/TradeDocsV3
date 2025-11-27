namespace TradeDocsV3.Forms
{
    partial class ServiceConfigForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConn = new System.Windows.Forms.TabPage();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // --- Connections ---
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox(); // 1C
            this.label2 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox(); // Intermediate
            this.label3 = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();

            // --- Tables ---
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFull = new System.Windows.Forms.DataGridViewCheckBoxColumn();

            this.tabControl.SuspendLayout();
            this.tabConn.SuspendLayout();
            this.tabTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // Tabs
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Controls.Add(this.tabConn);
            this.tabControl.Controls.Add(this.tabTables);

            // Tab 1: Conn
            this.tabConn.Text = "Основні налаштування";
            this.tabConn.Controls.Add(this.label1); this.tabConn.Controls.Add(this.txtSource);
            this.tabConn.Controls.Add(this.label2); this.tabConn.Controls.Add(this.txtTarget);
            this.tabConn.Controls.Add(this.label3); this.tabConn.Controls.Add(this.numInterval);

            this.label1.Text = "Джерело (1С MSSQL):"; this.label1.Location = new System.Drawing.Point(20, 20); this.label1.AutoSize = true;
            this.txtSource.Location = new System.Drawing.Point(20, 40); this.txtSource.Size = new System.Drawing.Size(500, 23);

            this.label2.Text = "Ціль (Проміжна MSSQL):"; this.label2.Location = new System.Drawing.Point(20, 80); this.label2.AutoSize = true;
            this.txtTarget.Location = new System.Drawing.Point(20, 100); this.txtTarget.Size = new System.Drawing.Size(500, 23);

            this.label3.Text = "Інтервал синхронізації (сек):"; this.label3.Location = new System.Drawing.Point(20, 150); this.label3.AutoSize = true;
            this.numInterval.Location = new System.Drawing.Point(200, 148); this.numInterval.Maximum = 36000; this.numInterval.Minimum = 10;

            // Tab 2: Tables
            this.tabTables.Text = "Таблиці";
            this.tabTables.Controls.Add(this.dgv);
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSrc, colTrg, colKey, colVer, colFull });

            this.colSrc.HeaderText = "Джерело"; this.colSrc.Name = "SourceTable";
            this.colTrg.HeaderText = "Приймач"; this.colTrg.Name = "TargetTable";
            this.colKey.HeaderText = "Ключ (ID)"; this.colKey.Name = "KeyColumn";
            this.colVer.HeaderText = "Версія"; this.colVer.Name = "VersionColumn";
            this.colFull.HeaderText = "Full"; this.colFull.Name = "FullSync"; this.colFull.Width = 50;

            // Bottom
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlBottom.Height = 50;
            this.pnlBottom.Controls.Add(this.btnSave); this.pnlBottom.Controls.Add(this.btnCancel);

            this.btnSave.Text = "Зберегти конфіг служби"; this.btnSave.Location = new System.Drawing.Point(350, 10); this.btnSave.Size = new System.Drawing.Size(160, 30);
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen; this.btnSave.ForeColor = System.Drawing.Color.White; this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Закрити"; this.btnCancel.Location = new System.Drawing.Point(520, 10); this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += (s, e) => Close();

            // Form
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlBottom);
            this.Text = "Налаштування Служби (1C -> Intermediate)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.tabControl.ResumeLayout(false);
            this.tabConn.ResumeLayout(false); this.tabConn.PerformLayout();
            this.tabTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConn, tabTables;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.Label label1, label2, label3;
        private System.Windows.Forms.TextBox txtSource, txtTarget;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrc, colTrg, colKey, colVer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFull;
    }
}