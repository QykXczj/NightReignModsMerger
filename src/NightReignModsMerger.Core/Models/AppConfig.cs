namespace NightReignModsMerger.Core.Models;

public class AppConfig
{
    public string GamePath { get; set; } = string.Empty;
    public string ModsToMergeFolderPath { get; set; } = "ModsToMerge";
    public string MergedModsFolderPath { get; set; } = "MergedMods";
    public bool BackupEnabled { get; set; } = true;
    public string BackupFolderPath { get; set; } = "Backups";
    public string LogLevel { get; set; } = "Information";
    public bool AutoDetectGamePath { get; set; } = true;
    public List<string> SupportedFileExtensions { get; set; } = new() { ".bin", ".param", ".dcx" };
    public int MaxBackups { get; set; } = 10;
    public string ConflictResolution { get; set; } = "Manual";
    public string Language { get; set; } = "zh-CN";
    public bool CheckForUpdates { get; set; } = true;
}