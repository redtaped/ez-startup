namespace EzStartup.Common.Models;

public class Configuration
{
    public Dictionary<string, ApplicationInfo> Launch { get; set; } = new Dictionary<string, ApplicationInfo>();
}