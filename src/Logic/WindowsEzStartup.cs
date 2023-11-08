using System.Diagnostics;
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

    public void Launch(string fileName, string arguments)
    {
        _logger.LogInformation("Opening {FileName}", fileName); // this is using structured logging ref: https://github.com/NLog/NLog/wiki/How-to-use-structured-logging
        
        Process.Start(new ProcessStartInfo{
            FileName = fileName,
            Arguments = arguments
        });
    }
}