namespace TradeDocsV3.Forms
{
    partial class SyncForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.rtbLog = new System.Windows.Forms.RichTextBox();

            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // Top Panel with Button and Progress
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 80;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTop.Controls.Add(this.btnStart);
            this.pnlTop.Controls.Add(this.progressBar);

            // btnStart
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStart.Height = 35;
            this.btnStart.Text = "🔄 ЗАПУСТИТИ СИНХРОНІЗАЦІЮ";
            this.btnStart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // progressBar
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Height = 10;

            // Log
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.rtbLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.ReadOnly = true;

            // Form
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.pnlTop);
            this.Text = "Синхронізація даних";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}