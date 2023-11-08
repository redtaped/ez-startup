// See https://aka.ms/new-console-template for more information
using EzStartup.Common;
using EzStartup.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// use application builder to get DI stuff for free 
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// add dependencies
builder.Services.AddBusinessLogic();    // wires up all logic classes, such as IEzStartup
builder.Services.AddLogging(o => {      // wires up ILogger<T> to use logging in our code
    o.AddConsole();                     // setsup logger to do console logs by default. later we can change this to event log or a file
});         

// build all dependencies and create a host to rul our application
using IHost host = builder.Build();

// create a new scope. a scope is a unit of work. 
// in this case we just have one scope, but for a web api this would usually represent a web request
using IServiceScope scope = host.Services.CreateScope();

// grab the entry point to the business logic and invoke it
// we may change this later to be cleaner, but this is the syntax
var startup = scope.ServiceProvider.GetRequiredService<IEzStartup>();
startup.Launch("explorer.exe", $"shell:AppsFolder\\WatchtowerBibleandTractSo.45909CDBADF3C_5rz59y55nfz3e!App");

// https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
await host.RunAsync();

