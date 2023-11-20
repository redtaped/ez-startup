using EzStartup.Common;
using Logic;
using Microsoft.Extensions.DependencyInjection;

namespace EzStartup.Logic;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        return serviceCollection
                .AddScoped<ILoader, Loader>()
                .AddScoped<IWindowsPositioner,WindowsPositioner>()
                .AddScoped<ILaunchApps, AppLauncher>();
    }
}