using System.Diagnostics;
using EzStartup.Common;
using Microsoft.Extensions.Logging;

namespace EzStartup.Logic;

internal class AppLauncher : ILaunchApps
{
    private readonly ILogger<AppLauncher> _logger;

    public AppLauncher(ILogger<AppLauncher> logger)
    {
        this._logger = logger;
    }

    public void Launch(string fileName, string arguments)
    {
        _logger.LogInformation("Opening {FileName}", fileName); // this is using structured logging ref: https://github.com/NLog/NLog/wiki/How-to-use-structured-logging
        
        Process.Start(new ProcessStartInfo{
            FileName = fileName,
            Arguments = arguments
        });
    }
}