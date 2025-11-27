namespace TradeDocsV3.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            tabConn = new TabPage();
            grpConn = new GroupBox();
            label1 = new Label();
            txtMssql = new TextBox();
            label2 = new Label();
            txtSqlite = new TextBox();
            chkEncrypt = new CheckBox();
            pnlConnBtns = new Panel();
            btnCancelConn = new Button();
            btnSaveConn = new Button();
            tabMap = new TabPage();
            dgvMaps = new DataGridView();
            colMapRole = new DataGridViewTextBoxColumn();
            colMapTable = new DataGridViewTextBoxColumn();
            colMapVer = new DataGridViewTextBoxColumn();
            colMapFilter = new DataGridViewTextBoxColumn();
            colMapFull = new DataGridViewCheckBoxColumn();
            colMapFieldsCount = new DataGridViewTextBoxColumn();
            pnlMapTop = new Panel();
            btnLoadJson = new Button();
            btnEditMap = new Button();
            pnlMapBtns = new Panel();
            btnCancelMap = new Button();
            btnSaveMap = new Button();
            tabControl.SuspendLayout();
            tabConn.SuspendLayout();
            grpConn.SuspendLayout();
            pnlConnBtns.SuspendLayout();
            tabMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaps).BeginInit();
            pnlMapTop.SuspendLayout();
            pnlMapBtns.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabConn);
            tabControl.Controls.Add(tabMap);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 9F);
            tabControl.ItemSize = new Size(150, 30);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 500);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabConn
            // 
            tabConn.BackColor = Color.White;
            tabConn.Controls.Add(grpConn);
            tabConn.Controls.Add(pnlConnBtns);
            tabConn.Location = new Point(4, 34);
            tabConn.Name = "tabConn";
            tabConn.Padding = new Padding(10);
            tabConn.Size = new Size(792, 462);
            tabConn.TabIndex = 0;
            tabConn.Text = "🔌 Підключення";
            // 
            // grpConn
            // 
            grpConn.Controls.Add(label1);
            grpConn.Controls.Add(txtMssql);
            grpConn.Controls.Add(label2);
            grpConn.Controls.Add(txtSqlite);
            grpConn.Controls.Add(chkEncrypt);
            grpConn.Dock = DockStyle.Fill;
            grpConn.Location = new Point(10, 10);
            grpConn.Name = "grpConn";
            grpConn.Size = new Size(772, 392);
            grpConn.TabIndex = 0;
            grpConn.TabStop = false;
            grpConn.Text = "Параметри баз даних";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(199, 15);
            label1.TabIndex = 0;
            label1.Text = "Рядок підключення до 1С (MSSQL):";
            // 
            // txtMssql
            // 
            txtMssql.Location = new Point(20, 50);
            txtMssql.Name = "txtMssql";
            txtMssql.Size = new Size(700, 23);
            txtMssql.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 90);
            label2.Name = "label2";
            label2.Size = new Size(265, 15);
            label2.TabIndex = 2;
            label2.Text = "Рядок підключення до локальної бази (SQLite):";
            // 
            // txtSqlite
            // 
            txtSqlite.Location = new Point(20, 110);
            txtSqlite.Name = "txtSqlite";
            txtSqlite.Size = new Size(700, 23);
            txtSqlite.TabIndex = 3;
            // 
            // chkEncrypt
            // 
            chkEncrypt.AutoSize = true;
            chkEncrypt.Location = new Point(20, 150);
            chkEncrypt.Name = "chkEncrypt";
            chkEncrypt.Size = new Size(320, 19);
            chkEncrypt.TabIndex = 4;
            chkEncrypt.Text = "Шифрувати рядки підключення у файлі налаштувань";
            // 
            // pnlConnBtns
            // 
            pnlConnBtns.Controls.Add(btnCancelConn);
            pnlConnBtns.Controls.Add(btnSaveConn);
            pnlConnBtns.Dock = DockStyle.Bottom;
            pnlConnBtns.Location = new Point(10, 402);
            pnlConnBtns.Name = "pnlConnBtns";
            pnlConnBtns.Size = new Size(772, 50);
            pnlConnBtns.TabIndex = 1;
            // 
            // btnCancelConn
            // 
            btnCancelConn.BackColor = Color.LightGray;
            btnCancelConn.FlatStyle = FlatStyle.Flat;
            btnCancelConn.Location = new Point(180, 10);
            btnCancelConn.Name = "btnCancelConn";
            btnCancelConn.Size = new Size(150, 30);
            btnCancelConn.TabIndex = 0;
            btnCancelConn.Text = "Відмінити зміни";
            btnCancelConn.UseVisualStyleBackColor = false;
            btnCancelConn.Click += btnCancelConn_Click;
            // 
            // btnSaveConn
            // 
            btnSaveConn.BackColor = Color.DodgerBlue;
            btnSaveConn.FlatStyle = FlatStyle.Flat;
            btnSaveConn.ForeColor = Color.White;
            btnSaveConn.Location = new Point(20, 10);
            btnSaveConn.Name = "btnSaveConn";
            btnSaveConn.Size = new Size(150, 30);
            btnSaveConn.TabIndex = 1;
            btnSaveConn.Text = "💾 Зберегти зміни";
            btnSaveConn.UseVisualStyleBackColor = false;
            btnSaveConn.Click += btnSaveConn_Click;
            // 
            // tabMap
            // 
            tabMap.BackColor = Color.White;
            tabMap.Controls.Add(dgvMaps);
            tabMap.Controls.Add(pnlMapTop);
            tabMap.Controls.Add(pnlMapBtns);
            tabMap.Location = new Point(4, 34);
            tabMap.Name = "tabMap";
            tabMap.Padding = new Padding(10);
            tabMap.Size = new Size(792, 462);
            tabMap.TabIndex = 1;
            tabMap.Text = "🗂 Структура даних";
            // 
            // dgvMaps
            // 
            dgvMaps.AllowUserToAddRows = false;
            dgvMaps.BackgroundColor = Color.White;
            dgvMaps.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F);
            dgvMaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaps.ColumnHeadersHeight = 35;
            dgvMaps.Columns.AddRange(new DataGridViewColumn[] { colMapRole, colMapTable, colMapVer, colMapFilter, colMapFull, colMapFieldsCount });
            dgvMaps.Dock = DockStyle.Fill;
            dgvMaps.EnableHeadersVisualStyles = false;
            dgvMaps.Location = new Point(10, 60);
            dgvMaps.Name = "dgvMaps";
            dgvMaps.RowHeadersVisible = false;
            dgvMaps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaps.Size = new Size(772, 342);
            dgvMaps.TabIndex = 0;
            // 
            // colMapRole
            // 
            colMapRole.HeaderText = "Роль";
            colMapRole.Name = "colMapRole";
            colMapRole.Width = 150;
            // 
            // colMapTable
            // 
            colMapTable.HeaderText = "Таблиця 1С";
            colMapTable.Name = "colMapTable";
            colMapTable.Width = 200;
            // 
            // colMapVer
            // 
            colMapVer.HeaderText = "Версія";
            colMapVer.Name = "colMapVer";
            colMapVer.Width = 80;
            // 
            // colMapFilter
            // 
            colMapFilter.HeaderText = "Фільтр";
            colMapFilter.Name = "colMapFilter";
            colMapFilter.Width = 60;
            // 
            // colMapFull
            // 
            colMapFull.HeaderText = "Full";
            colMapFull.Name = "colMapFull";
            colMapFull.Width = 40;
            // 
            // colMapFieldsCount
            // 
            colMapFieldsCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMapFieldsCount.HeaderText = "Полів";
            colMapFieldsCount.Name = "colMapFieldsCount";
            // 
            // pnlMapTop
            // 
            pnlMapTop.Controls.Add(btnLoadJson);
            pnlMapTop.Controls.Add(btnEditMap);
            pnlMapTop.Dock = DockStyle.Top;
            pnlMapTop.Location = new Point(10, 10);
            pnlMapTop.Name = "pnlMapTop";
            pnlMapTop.Size = new Size(772, 50);
            pnlMapTop.TabIndex = 1;
            // 
            // btnLoadJson
            // 
            btnLoadJson.BackColor = Color.Orange;
            btnLoadJson.FlatStyle = FlatStyle.Flat;
            btnLoadJson.ForeColor = Color.White;
            btnLoadJson.Location = new Point(0, 10);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(220, 30);
            btnLoadJson.TabIndex = 0;
            btnLoadJson.Text = "📂 Завантажити з файлу (JSON)";
            btnLoadJson.UseVisualStyleBackColor = false;
            btnLoadJson.Click += btnLoadJson_Click;
            // 
            // btnEditMap
            // 
            btnEditMap.BackColor = Color.SteelBlue;
            btnEditMap.FlatStyle = FlatStyle.Flat;
            btnEditMap.ForeColor = Color.White;
            btnEditMap.Location = new Point(230, 10);
            btnEditMap.Name = "btnEditMap";
            btnEditMap.Size = new Size(160, 30);
            btnEditMap.TabIndex = 1;
            btnEditMap.Text = "⚙ Налаштувати вибране";
            btnEditMap.UseVisualStyleBackColor = false;
            btnEditMap.Click += btnEditMap_Click;
            // 
            // pnlMapBtns
            // 
            pnlMapBtns.Controls.Add(btnCancelMap);
            pnlMapBtns.Controls.Add(btnSaveMap);
            pnlMapBtns.Dock = DockStyle.Bottom;
            pnlMapBtns.Location = new Point(10, 402);
            pnlMapBtns.Name = "pnlMapBtns";
            pnlMapBtns.Size = new Size(772, 50);
            pnlMapBtns.TabIndex = 2;
            // 
            // btnCancelMap
            // 
            btnCancelMap.BackColor = Color.LightGray;
            btnCancelMap.FlatStyle = FlatStyle.Flat;
            btnCancelMap.Location = new Point(160, 10);
            btnCancelMap.Name = "btnCancelMap";
            btnCancelMap.Size = new Size(150, 30);
            btnCancelMap.TabIndex = 0;
            btnCancelMap.Text = "Відмінити зміни";
            btnCancelMap.UseVisualStyleBackColor = false;
            btnCancelMap.Click += btnCancelMap_Click;
            // 
            // btnSaveMap
            // 
            btnSaveMap.BackColor = Color.DodgerBlue;
            btnSaveMap.FlatStyle = FlatStyle.Flat;
            btnSaveMap.ForeColor = Color.White;
            btnSaveMap.Location = new Point(0, 10);
            btnSaveMap.Name = "btnSaveMap";
            btnSaveMap.Size = new Size(150, 30);
            btnSaveMap.TabIndex = 1;
            btnSaveMap.Text = "💾 Зберегти зміни";
            btnSaveMap.UseVisualStyleBackColor = false;
            btnSaveMap.Click += btnSaveMap_Click;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(tabControl);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Налаштування системи";
            tabControl.ResumeLayout(false);
            tabConn.ResumeLayout(false);
            grpConn.ResumeLayout(false);
            grpConn.PerformLayout();
            pnlConnBtns.ResumeLayout(false);
            tabMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaps).EndInit();
            pnlMapTop.ResumeLayout(false);
            pnlMapBtns.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Variables
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConn, tabMap;

        // Tab 1
        private System.Windows.Forms.GroupBox grpConn;
        private System.Windows.Forms.TextBox txtMssql, txtSqlite;
        private System.Windows.Forms.Label label1, label2;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.Panel pnlConnBtns;
        private System.Windows.Forms.Button btnSaveConn, btnCancelConn;

        // Tab 2
        private System.Windows.Forms.DataGridView dgvMaps;
        private System.Windows.Forms.Panel pnlMapTop, pnlMapBtns;
        private System.Windows.Forms.Button btnLoadJson, btnEditMap;
        private System.Windows.Forms.Button btnSaveMap, btnCancelMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMapRole, colMapTable, colMapVer, colMapFilter, colMapFieldsCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMapFull;
    }
}