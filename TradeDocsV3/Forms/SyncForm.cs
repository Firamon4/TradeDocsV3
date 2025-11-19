using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using TradeDocsV3.Data.Sync;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class SyncForm : Form
{
    private readonly AppSettings _settings;
    private readonly ILogger _logger;

    public SyncForm(AppSettings settings)
    {
        InitializeComponent();
        _settings = settings;
        _logger = new RichTextLogger(rtbLog); // Спрощено
    }

    private async void btnStart_Click(object sender, EventArgs e)
    {
        btnStart.Enabled = false;
        progressBar.Style = ProgressBarStyle.Marquee;
        rtbLog.Clear();

        try
        {
            var config = new SyncConfig
            {
                // Просто беремо рядок як є
                SourceConnStr = _settings.Database.EncryptedMSSQL,
                TargetConnStr = _settings.Database.EncryptedSQLite,
                Mappings = _settings.Sync.Mappings
            };

            var service = new DatabaseSyncService(config, _logger);
            await Task.Run(() => service.Sync());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        finally
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            btnStart.Enabled = true;
        }
    }
}