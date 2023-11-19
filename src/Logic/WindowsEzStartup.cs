using System.Diagnostics;
using Common.Models;
using EzStartup.Common;
using Microsoft.Extensions.Logging;

namespace EzStartup.Logic;

internal class WindowsEzStartup : IEzStartup
{
    private readonly ILogger<WindowsEzStartup> _logger;

    public WindowsEzStartup(ILogger<WindowsEzStartup> logger)
    {
        this._logger = logger;
    }

    public void Launch(WindowsStartupApp app)
    {
        _logger.LogInformation("Opening {AppName}", app.AppName); // this is using structured logging ref: https://github.com/NLog/NLog/wiki/How-to-use-structured-logging
        
        Process.Start(new ProcessStartInfo{
            FileName = "explorer.exe",
            Arguments = $"shell:AppsFolder\\{app.AppId}"
        });
    }

    public void LaunchMany(List<WindowsStartupApp> startupApps){
        startupApps.ForEach(app => Launch(app));
    }
}