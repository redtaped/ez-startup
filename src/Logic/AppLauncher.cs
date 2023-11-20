using System.Diagnostics;
using EzStartup.Logic;
using Microsoft.Extensions.Logging;

namespace EzStartup.Logic;

internal class AppLauncher : ILaunchApps
{
    private readonly ILogger<AppLauncher> _logger;

    public AppLauncher(ILogger<AppLauncher> logger)
    {
        this._logger = logger;
    }

    public Process Launch(string fileName, string arguments, string? workingDirectory = null)
    {
        _logger.LogInformation("Opening {FileName}", fileName); // this is using structured logging ref: https://github.com/NLog/NLog/wiki/How-to-use-structured-logging
        
        Process? process = Process.Start(new ProcessStartInfo{
            FileName = fileName,
            Arguments = arguments,
            UseShellExecute = false,
            WorkingDirectory = workingDirectory 
        });

        if(process == null){
            throw new Exception($"Unable to open {fileName}");
        }
        return process;
    }


}