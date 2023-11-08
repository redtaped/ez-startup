using EzStartup.Common;
using Microsoft.Extensions.DependencyInjection;

namespace EzStartup.Logic;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IEzStartup, WindowsEzStartup>();
    }
}