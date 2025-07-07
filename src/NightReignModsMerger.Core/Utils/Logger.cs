using Serilog;
using Serilog.Events;

namespace NightReignModsMerger.Core.Utils;

public static class Logger
{
    private static ILogger? _logger;
    private static readonly List<LogEntry> _logEntries = new();
    public static event Action<LogEntry>? LogEntryAdded;

    public static void Initialize(string logLevel = "Information", string? logFilePath = null)
    {
        var loggerConfig = new LoggerConfiguration()
            .MinimumLevel.Is(ParseLogLevel(logLevel))
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");

        if (!string.IsNullOrEmpty(logFilePath))
        {
            var logDir = Path.GetDirectoryName(logFilePath);
            if (!string.IsNullOrEmpty(logDir) && !Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
            loggerConfig.WriteTo.File(
                logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message:lj}{NewLine}{Exception}");
        }

        _logger = loggerConfig.CreateLogger();
        Log.Logger = _logger;
    }

    private static LogEventLevel ParseLogLevel(string logLevel)
    {
        return logLevel.ToLowerInvariant() switch
        {
            "verbose" => LogEventLevel.Verbose,
            "debug" => LogEventLevel.Debug,
            "information" => LogEventLevel.Information,
            "warning" => LogEventLevel.Warning,
            "error" => LogEventLevel.Error,
            "fatal" => LogEventLevel.Fatal,
            _ => LogEventLevel.Information
        };
    }

    private static void AddLogEntry(LogLevel level, string message, Exception? exception = null)
    {
        var entry = new LogEntry
        {
            Timestamp = DateTime.Now,
            Level = level,
            Message = message,
            Exception = exception
        };
        
        _logEntries.Add(entry);
        LogEntryAdded?.Invoke(entry);
        
        // Keep only last 1000 entries
        if (_logEntries.Count > 1000)
        {
            _logEntries.RemoveAt(0);
        }
    }

    public static void Info(string message)
    {
        _logger?.Information(message);
        AddLogEntry(LogLevel.Information, message);
    }

    public static void Debug(string message)
    {
        _logger?.Debug(message);
        AddLogEntry(LogLevel.Debug, message);
    }

    public static void Warning(string message)
    {
        _logger?.Warning(message);
        AddLogEntry(LogLevel.Warning, message);
    }

    public static void Error(string message)
    {
        _logger?.Error(message);
        AddLogEntry(LogLevel.Error, message);
    }

    public static void Error(Exception ex, string message)
    {
        _logger?.Error(ex, message);
        AddLogEntry(LogLevel.Error, message, ex);
    }

    public static void Fatal(string message)
    {
        _logger?.Fatal(message);
        AddLogEntry(LogLevel.Fatal, message);
    }

    public static void Fatal(Exception ex, string message)
    {
        _logger?.Fatal(ex, message);
        AddLogEntry(LogLevel.Fatal, message, ex);
    }

    public static List<LogEntry> GetLogEntries() => new(_logEntries);
}

public class LogEntry
{
    public DateTime Timestamp { get; set; }
    public LogLevel Level { get; set; }
    public string Message { get; set; } = string.Empty;
    public Exception? Exception { get; set; }
}

public enum LogLevel
{
    Verbose,
    Debug,
    Information,
    Warning,
    Error,
    Fatal
}