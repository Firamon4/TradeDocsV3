namespace TradeDocsV3.Forms
{
    partial class DocumentEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle gridStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();

            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeNomenclature = new System.Windows.Forms.TreeView();
            this.listNomenclature = new System.Windows.Forms.ListBox();

            this.pnlGridActions = new System.Windows.Forms.Panel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSum = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlGridActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            // --- HEADER ---
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblNum);
            this.pnlHeader.Controls.Add(this.txtNumber);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15);
            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "Документ";
            // txtNumber
            this.txtNumber.Location = new System.Drawing.Point(200, 20);
            this.txtNumber.Size = new System.Drawing.Size(150, 23);
            // lblNum
            this.lblNum.Text = "Номер:"; this.lblNum.Location = new System.Drawing.Point(140, 23); this.lblNum.AutoSize = true;
            // lblDate
            this.lblDate.Text = "01.01.2025"; this.lblDate.Location = new System.Drawing.Point(370, 23); this.lblDate.AutoSize = true; this.lblDate.ForeColor = System.Drawing.Color.Gray;

            // --- FOOTER ---
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.lblTotal);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 60;
            // lblTotal
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTotal.Location = new System.Drawing.Point(20, 20);
            this.lblTotal.AutoSize = true;
            this.lblTotal.Text = "Всього: 0.00 грн";
            // btnSave
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(750, 12);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Text = "💾 ЗБЕРЕГТИ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // --- SPLIT CONTAINER ---
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 60);
            this.splitContainer.Size = new System.Drawing.Size(900, 440); // Total - header - footer
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.SplitterWidth = 5;

            // Panel 1: Tree & List (Left)
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.treeNomenclature.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeNomenclature.Height = 200;
            this.treeNomenclature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.listNomenclature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listNomenclature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // Hack to add spacing between tree and list
            System.Windows.Forms.Panel spacer = new System.Windows.Forms.Panel(); spacer.Dock = System.Windows.Forms.DockStyle.Top; spacer.Height = 10;
            this.splitContainer.Panel1.Controls.Add(this.listNomenclature);
            this.splitContainer.Panel1.Controls.Add(spacer);
            this.splitContainer.Panel1.Controls.Add(this.treeNomenclature);

            // Panel 2: Grid & Actions (Right)
            this.splitContainer.Panel2.Controls.Add(this.dgvItems);
            this.splitContainer.Panel2.Controls.Add(this.pnlGridActions);

            // Grid Actions
            this.pnlGridActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridActions.Height = 40;
            this.pnlGridActions.Controls.Add(this.btnAddItem);
            // btnAdd
            this.btnAddItem.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(0, 5);
            this.btnAddItem.Size = new System.Drawing.Size(100, 30);
            this.btnAddItem.Text = "⬇ Додати";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);

            // Grid
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240),
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F),
                Padding = new System.Windows.Forms.Padding(5)
            };
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colItemName, this.colQty, this.colPrice, this.colSum });
            this.colItemName.HeaderText = "Товар";
            this.colQty.HeaderText = "К-ть";
            this.colPrice.HeaderText = "Ціна";
            this.colSum.HeaderText = "Сума";

            // Form
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Text = "Редактор документа";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false); this.pnlFooter.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlGridActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader, pnlFooter, pnlGridActions;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblTitle, lblNum, lblDate, lblTotal;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnSave, btnAddItem;
        private System.Windows.Forms.TreeView treeNomenclature;
        private System.Windows.Forms.ListBox listNomenclature;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName, colQty, colPrice, colSum;
    }
}