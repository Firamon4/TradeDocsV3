using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Windows.Forms;

namespace TradeDocsV3.Services;

// Якщо ви використовуєте ILoggerProvider (через Factory), залишіть цей клас.
// Якщо ви створюєте логер вручну (new RichTextLogger(...)), він не обов'язковий,
// але не завадить.
public class RichTextLoggerProvider : ILoggerProvider
{
    private readonly RichTextBox _box;
    private readonly ConcurrentDictionary<string, RichTextLogger> _loggers = new();

    public RichTextLoggerProvider(RichTextBox box) => _box = box;

    public ILogger CreateLogger(string categoryName) =>
        _loggers.GetOrAdd(categoryName, name => new RichTextLogger(_box));

    public void Dispose() => _loggers.Clear();
}

public class RichTextLogger : ILogger
{
    private readonly RichTextBox _box;
    private static readonly object _lock = new();

    public RichTextLogger(RichTextBox box) => _box = box;

    public IDisposable BeginScope<TState>(TState state) => null!;
    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId,
        TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var message = formatter(state, exception);
        var timestamp = DateTime.Now.ToString("HH:mm:ss");

        // Визначаємо колір на основі рівня або змісту повідомлення
        Color msgColor;
        string prefix;

        if (logLevel == LogLevel.Error || logLevel == LogLevel.Critical)
        {
            msgColor = Color.FromArgb(255, 100, 100); // Світло-червоний
            prefix = "[ERR ]";
        }
        else if (logLevel == LogLevel.Warning)
        {
            msgColor = Color.FromArgb(255, 215, 0); // Золотий/Жовтий
            prefix = "[WARN]";
        }
        else
        {
            // Для INFO розбираємо по тегах для краси
            if (message.Contains("[SCHEMA]"))
            {
                msgColor = Color.FromArgb(100, 200, 255); // Блакитний
                prefix = ""; // Тег вже є в повідомленні
            }
            else if (message.Contains("[DATA]") || message.Contains("[OK]") || message.Contains("[DONE]"))
            {
                msgColor = Color.LightGreen; // Зелений
                prefix = "";
            }
            else if (message.Contains("[TABLE]") || message.Contains("[SYNC]"))
            {
                msgColor = Color.White;
                prefix = "";
            }
            else
            {
                msgColor = Color.LightGray; // Звичайний текст
                prefix = "[INFO]";
            }
        }

        if (_box.IsDisposed) return;

        // Виконуємо в UI потоці
        Action append = () =>
        {
            lock (_lock)
            {
                if (_box.IsDisposed) return;

                // 1. Час (Тьмяний)
                _box.SelectionStart = _box.TextLength;
                _box.SelectionLength = 0;
                _box.SelectionColor = Color.Gray;
                _box.SelectionFont = new Font("Consolas", 9F, FontStyle.Regular);
                _box.AppendText($"{timestamp} ");

                // 2. Префікс/Повідомлення (Кольорове)
                _box.SelectionStart = _box.TextLength;
                _box.SelectionLength = 0;
                _box.SelectionColor = msgColor;

                // Робимо помилки та заголовки жирними
                FontStyle style = FontStyle.Regular;
                if (logLevel >= LogLevel.Warning || message.Contains("===="))
                    style = FontStyle.Bold;

                _box.SelectionFont = new Font("Consolas", 10F, style);

                string fullMsg = string.IsNullOrEmpty(prefix) ? message : $"{prefix} {message}";
                _box.AppendText($"{fullMsg}\n");

                _box.ScrollToCaret();
            }
        };

        if (_box.InvokeRequired)
            _box.Invoke(append);
        else
            append();
    }
}