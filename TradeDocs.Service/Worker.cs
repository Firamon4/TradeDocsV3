using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeDocs.Data.Sync; // З нашої Core бібліотеки
using TradeDocs.Services;  // З нашої Core бібліотеки

namespace TradeDocs.Service;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("TradeDocs Service запущено.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // 1. Завантажуємо налаштування зі СПІЛЬНОГО файлу
                var settings = ConfigManager.Load();

                // 2. Перевіряємо, чи увімкнена авто-синхронізація
                // (Припустимо, ви додали галочку AutoSyncEnabled в AppSettings, або просто працюємо завжди)
                // Якщо хочете керувати запуском, додайте bool ServiceEnabled в AppSettings.

                if (string.IsNullOrEmpty(settings.Database.EncryptedMSSQL) || string.IsNullOrEmpty(settings.Database.EncryptedSQLite))
                {
                    _logger.LogWarning("Рядки підключення не налаштовані. Очікування...");
                }
                else
                {
                    // 3. Запускаємо нашу логіку синхронізації
                    // Створюємо конфіг для сервісу на основі AppSettings
                    var syncConfig = new SyncConfig
                    {
                        SourceConnStr = settings.Database.EncryptedMSSQL, // Вже розшифровані в Load()
                        TargetConnStr = settings.Database.EncryptedSQLite,
                        Mappings = settings.Sync.Mappings
                    };

                    var syncService = new DatabaseSyncService(syncConfig, _logger);

                    _logger.LogInformation("Початок циклу синхронізації...");
                    syncService.Sync();
                }

                // 4. Чекаємо інтервал (наприклад, 60 сек, або з налаштувань)
                int delay = 60; // Можна брати з settings.Sync.IntervalSeconds
                await Task.Delay(TimeSpan.FromSeconds(delay), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Критична помилка сервісу.");
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}