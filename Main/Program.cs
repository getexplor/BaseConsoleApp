using Features.Interfaces;
using Features.Services;
using Main;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scoped = host.Services.CreateScope();

var services = scoped.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//create host builder for Depedency Injection
static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_,services) =>
        {
            services.AddSingleton<ILanguageService, LanguagesService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<App>();
        });
}
