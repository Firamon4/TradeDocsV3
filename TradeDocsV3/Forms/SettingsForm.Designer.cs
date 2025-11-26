namespace TradeDocsV3.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle gridHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle gridHeaderStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConn = new System.Windows.Forms.TabPage();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();

            // --- Tab 1: Connections ---
            this.grpConn = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMssql = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSqlite = new System.Windows.Forms.TextBox();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();

            // --- Tab 2: Mapping ---
            this.dgvMaps = new System.Windows.Forms.DataGridView();

            // ІНІЦІАЛІЗАЦІЯ КОЛОНОК (Створюємо об'єкти, щоб не було NullReference)
            this.colMapRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMapTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMapVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMapFilter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMapFull = new System.Windows.Forms.DataGridViewCheckBoxColumn(); // Галочка
            this.colMapFieldsCount = new System.Windows.Forms.DataGridViewTextBoxColumn(); // Текст
            this.colMapDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlMapActions = new System.Windows.Forms.Panel();
            this.btnAddMap = new System.Windows.Forms.Button();
            this.btnEditMap = new System.Windows.Forms.Button();
            this.btnDelMap = new System.Windows.Forms.Button();

            // --- Tab 3: Users ---
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.colUserLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserLast = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlUserActions = new System.Windows.Forms.Panel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDelUser = new System.Windows.Forms.Button();

            this.pnlBottom.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConn.SuspendLayout();
            this.grpConn.SuspendLayout();
            this.tabMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
            this.pnlMapActions.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlUserActions.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlBottom (Кнопки)
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 60;
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            // Верхня межа для краси
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);

            // btnSave
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(560, 12);
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.Text = "💾 Зберегти";
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(680, 12);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Text = "Закрити";
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Controls.Add(this.tabConn);
            this.tabControl.Controls.Add(this.tabMap);
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl.ItemSize = new System.Drawing.Size(120, 30);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;

            // TAB 1
            this.tabConn.Text = "🔌 Підключення";
            this.tabConn.Padding = new System.Windows.Forms.Padding(15);
            this.tabConn.BackColor = System.Drawing.Color.White;
            this.tabConn.Controls.Add(this.grpConn);

            this.grpConn.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConn.Height = 200;
            this.grpConn.Text = "Параметри баз даних";
            this.grpConn.Controls.Add(this.label1); this.grpConn.Controls.Add(this.txtMssql);
            this.grpConn.Controls.Add(this.label2); this.grpConn.Controls.Add(this.txtSqlite);
            this.grpConn.Controls.Add(this.chkEncrypt);

            this.label1.Text = "Рядок підключення до 1С (MSSQL):"; this.label1.Location = new System.Drawing.Point(20, 30); this.label1.AutoSize = true;
            this.txtMssql.Location = new System.Drawing.Point(20, 50); this.txtMssql.Size = new System.Drawing.Size(700, 23);
            this.label2.Text = "Рядок підключення до локальної бази (SQLite):"; this.label2.Location = new System.Drawing.Point(20, 90); this.label2.AutoSize = true;
            this.txtSqlite.Location = new System.Drawing.Point(20, 110); this.txtSqlite.Size = new System.Drawing.Size(700, 23);
            this.chkEncrypt.Text = "Шифрувати рядки підключення у файлі налаштувань";
            this.chkEncrypt.Location = new System.Drawing.Point(20, 150); this.chkEncrypt.AutoSize = true;

            // TAB 2
            this.tabMap.Text = "🗂 Структура даних";
            this.tabMap.BackColor = System.Drawing.Color.White;
            this.tabMap.Controls.Add(this.dgvMaps);
            this.tabMap.Controls.Add(this.pnlMapActions);

            this.dgvMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaps.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaps.AllowUserToAddRows = false;
            this.dgvMaps.RowHeadersVisible = false;
            this.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            gridHeaderStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            gridHeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.dgvMaps.ColumnHeadersDefaultCellStyle = gridHeaderStyle;
            this.dgvMaps.ColumnHeadersHeight = 35;

            // ВАЖЛИВО: Порядок колонок ТУТ має співпадати з SettingsForm.cs (RefreshMaps)
            // 0:Role, 1:Table, 2:Ver, 3:Filter, 4:Full(Check), 5:Count(Text), 6:Desc
            this.dgvMaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMapRole,
                this.colMapTable,
                this.colMapVer,
                this.colMapFilter,
                this.colMapFull,        // Чекбокс (індекс 4)
                this.colMapFieldsCount, // Текст (індекс 5)
                this.colMapDesc
            });

            this.colMapRole.HeaderText = "Роль"; this.colMapRole.Width = 140;
            this.colMapTable.HeaderText = "Таблиця 1С"; this.colMapTable.Width = 180;
            this.colMapVer.HeaderText = "Версія"; this.colMapVer.Width = 80;
            this.colMapFilter.HeaderText = "Фільтр"; this.colMapFilter.Width = 60; this.colMapFilter.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMapFull.HeaderText = "Full"; this.colMapFull.Width = 40; this.colMapFull.ReadOnly = true;
            this.colMapFieldsCount.HeaderText = "Полів"; this.colMapFieldsCount.Width = 60; this.colMapFieldsCount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMapDesc.HeaderText = "Опис"; this.colMapDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            // Buttons Map
            this.pnlMapActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMapActions.Height = 45;
            this.pnlMapActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMapActions.Controls.Add(this.btnAddMap); this.pnlMapActions.Controls.Add(this.btnEditMap); this.pnlMapActions.Controls.Add(this.btnDelMap);

            this.btnAddMap.Text = "➕ Додати"; this.btnAddMap.Location = new System.Drawing.Point(5, 8); this.btnAddMap.Size = new System.Drawing.Size(90, 30); this.btnAddMap.Click += new System.EventHandler(this.btnAddMap_Click);
            this.btnEditMap.Text = "✎ Змінити"; this.btnEditMap.Location = new System.Drawing.Point(100, 8); this.btnEditMap.Size = new System.Drawing.Size(90, 30); this.btnEditMap.Click += new System.EventHandler(this.btnEditMap_Click);
            this.btnDelMap.Text = "🗑 Видалити"; this.btnDelMap.Location = new System.Drawing.Point(195, 8); this.btnDelMap.Size = new System.Drawing.Size(90, 30); this.btnDelMap.Click += new System.EventHandler(this.btnDelMap_Click);

            // TAB 3
            this.tabUsers.Text = "👥 Користувачі";
            this.tabUsers.BackColor = System.Drawing.Color.White;
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.pnlUserActions);

            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.AllowUserToAddRows = false; this.dgvUsers.RowHeadersVisible = false; this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = gridHeaderStyle;
            this.dgvUsers.ColumnHeadersHeight = 35;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colUserLogin, this.colUserRole, this.colUserActive, this.colUserLast });
            this.colUserLogin.HeaderText = "Логін"; this.colUserLogin.DataPropertyName = "Login"; this.colUserLogin.Width = 150;
            this.colUserRole.HeaderText = "Роль"; this.colUserRole.DataPropertyName = "Role"; this.colUserRole.Width = 120;
            this.colUserActive.HeaderText = "Актив"; this.colUserActive.DataPropertyName = "IsActive"; this.colUserActive.Width = 60;
            this.colUserLast.HeaderText = "Останній вхід"; this.colUserLast.DataPropertyName = "LastLoginAt"; this.colUserLast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            this.pnlUserActions.Dock = System.Windows.Forms.DockStyle.Top; this.pnlUserActions.Height = 45; this.pnlUserActions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlUserActions.Controls.Add(this.btnAddUser); this.pnlUserActions.Controls.Add(this.btnEditUser); this.pnlUserActions.Controls.Add(this.btnDelUser);
            this.btnAddUser.Text = "➕ Додати"; this.btnAddUser.Location = new System.Drawing.Point(5, 8); this.btnAddUser.Size = new System.Drawing.Size(90, 30); this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.btnEditUser.Text = "✎ Змінити"; this.btnEditUser.Location = new System.Drawing.Point(100, 8); this.btnEditUser.Size = new System.Drawing.Size(90, 30); this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            this.btnDelUser.Text = "🗑 Видалити"; this.btnDelUser.Location = new System.Drawing.Point(195, 8); this.btnDelUser.Size = new System.Drawing.Size(90, 30); this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 500);
            // ВАЖЛИВО: Спочатку TabControl, потім pnlBottom, щоб панель була "поверх" (або знизу за Dock)
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlBottom);
            this.Text = "Налаштування системи";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SettingsForm_Load);

            this.pnlBottom.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabConn.ResumeLayout(false);
            this.grpConn.ResumeLayout(false); this.grpConn.PerformLayout();
            this.tabMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
            this.pnlMapActions.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlUserActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConn, tabMap, tabUsers;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.GroupBox grpConn;
        private System.Windows.Forms.TextBox txtMssql, txtSqlite;
        private System.Windows.Forms.Label label1, label2;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.DataGridView dgvMaps;
        private System.Windows.Forms.Panel pnlMapActions;
        private System.Windows.Forms.Button btnAddMap, btnEditMap, btnDelMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMapRole, colMapTable, colMapVer, colMapFilter, colMapFieldsCount, colMapDesc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMapFull;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlUserActions;
        private System.Windows.Forms.Button btnAddUser, btnEditUser, btnDelUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserLogin, colUserRole, colUserLast;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUserActive;
    }
}