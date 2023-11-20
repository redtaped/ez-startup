using EzStartup.Common.Models;
using Logic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EzStartup.Logic;

internal class Loader : ILoader
{
    public Loader(
        IOptionsSnapshot<Configuration> configurationOptions,
        ILaunchApps ezStartup, 
        ILogger<Loader> logger, 
        IWindowsPositioner windowsPositioner
        )
    {
        _configuration = configurationOptions.Value;
        _startup = ezStartup;
        _logger = logger;
        _windowsPositioner = windowsPositioner;
    }

    private Configuration _configuration;
    private ILaunchApps _startup;
    private readonly ILogger<Loader> _logger;
    private readonly IWindowsPositioner _windowsPositioner;

    public void Start()
    {
        _logger.LogInformation("Loader reading from configuration sources to determine which applications to launch");
        _logger.LogInformation("{NumberOfApplications} found", _configuration.Launch.Keys.Count);
        
        foreach(var appKey in _configuration.Launch.Keys) 
        {
            _logger.LogInformation("Opening {AppName} from configuration", appKey);

            var launch = _configuration.Launch[appKey];
            try{
                var process = _startup.Launch(launch.FileName, 
                                launch.Arguments,
                                launch.WorkingDirectory);
                
                if (launch.Settings != null) 
                    _windowsPositioner.Position(
                            process,
                            launch.Settings.PositionX, 
                            launch.Settings.PositionY, 
                            launch.Settings.SizeX, 
                            launch.Settings.SizeY
                    );

            }catch(Exception e){
                _logger.LogError(e,"Unable to open file {FileName}",launch.FileName);
            }
            
        }
    }
}
