// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using EzStartup.Common;
using EzStartup.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// use application builder to get DI stuff for free 
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// add dependencies
builder.Services
    .Configure<Configuration>(builder.Configuration)    // wires up the options framework to the Configuration class
    .AddBusinessLogic()                                 // wires up all logic classes, such as IEzStartup
    .AddLogging(o => {                                  // wires up ILogger<T> to use logging in our code
        o.AddConsole();                                 // setsup logger to do console logs by default. later we can change this to event log or a file
    });     

builder.Configuration                                   // load the configuration for the running operating system
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile($"appsettings.{RuntimeInformation.RuntimeIdentifier}.json"); 

// build all dependencies and create a host to rul our application
using IHost host = builder.Build();

// create a new scope. a scope is a unit of work. 
// in this case we just have one scope, but for a web api this would usually represent a web request
using IServiceScope scope = host.Services.CreateScope();

// grab the entry point to the business logic and invoke it
// we may change this later to be cleaner, but this is the syntax
var startup = scope.ServiceProvider.GetRequiredService<ILoader>();
startup.Start();    // entry point, all business logic kicks off from this point

// https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
// await host.RunAsync();   // if we had a long running application we'd need these also
// await host.StopAsync();

