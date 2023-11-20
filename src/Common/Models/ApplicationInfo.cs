namespace EzStartup.Common.Models;

public class ApplicationInfo 
{
    public string FileName { get; set; } = string.Empty;
    public string Arguments {get; set; } = string.Empty;
    public string? WorkingDirectory { get; set; }
    public ApplicationConfiguration? Settings { get; set;}
}