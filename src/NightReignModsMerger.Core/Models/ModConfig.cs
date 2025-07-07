namespace NightReignModsMerger.Core.Models;

public class ModConfig
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public int Priority { get; set; } = 0;
    public List<ModFile> ModFiles { get; set; } = new();
    public bool IsDllMod { get; set; } = false;
    public string Version { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime LastModified { get; set; } = DateTime.MinValue;
    public long TotalSize { get; set; } = 0;
}

public class ModFile
{
    public string Path { get; set; } = string.Empty;
    public string ModRelativePath { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public bool IsDirectory { get; set; } = false;
    public long Size { get; set; } = 0;
    public DateTime LastModified { get; set; } = DateTime.MinValue;
    public string FileType { get; set; } = string.Empty;
    public bool HasConflicts { get; set; } = false;
}