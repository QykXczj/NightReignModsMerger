namespace NightReignModsMerger.Core.Models;

public class MergeResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Warnings { get; set; } = new();
    public List<string> Errors { get; set; } = new();
    public List<ConflictInfo> Conflicts { get; set; } = new();
    public TimeSpan Duration { get; set; }
    public int ProcessedFiles { get; set; }
    public int MergedParams { get; set; }
    public int NewRows { get; set; }
    public int ModifiedRows { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string OutputPath { get; set; } = string.Empty;
}

public class ConflictInfo
{
    public string ParamName { get; set; } = string.Empty;
    public int RowId { get; set; }
    public string FieldName { get; set; } = string.Empty;
    public object? CurrentValue { get; set; }
    public object? NewValue { get; set; }
    public object? VanillaValue { get; set; }
    public string SourceMod { get; set; } = string.Empty;
    public string TargetMod { get; set; } = string.Empty;
    public ConflictResolution Resolution { get; set; } = ConflictResolution.Pending;
    public ConflictSeverity Severity { get; set; } = ConflictSeverity.Medium;
}

public enum ConflictResolution
{
    Pending,
    KeepCurrent,
    UseNew,
    Manual,
    Skip
}

public enum ConflictSeverity
{
    Low,
    Medium,
    High,
    Critical
}