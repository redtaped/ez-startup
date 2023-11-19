using EzStartup.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

internal class Loader : ILoader
{
    public Loader(IOptionsSnapshot<Configuration> configurationOptions, ILaunchApps ezStartup, ILogger<Loader> logger)
    {
        _configuration = configurationOptions.Value;
        _startup = ezStartup;
        _logger = logger;
    }

    private Configuration _configuration;
    private ILaunchApps _startup;
    private readonly ILogger<Loader> _logger;

    public void Start()
    {
        _logger.LogInformation("Loader reading from configuration sources to determine which applications to launch");
        _logger.LogInformation("{NumberOfApplications} found", _configuration.Launch.Keys.Count);
        
        foreach(var appKey in _configuration.Launch.Keys) 
        {
            _logger.LogInformation("Opening {AppName} from configuration", appKey);

            _startup.Launch(_configuration.Launch[appKey].FileName, 
                            _configuration.Launch[appKey].Arguments,
                            _configuration.Launch[appKey].WorkingDirectory);
        }
    }
}
