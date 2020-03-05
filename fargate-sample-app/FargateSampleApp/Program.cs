using FargateSampleApp.Actions;
using FargateSampleApp.Health;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FargateSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var healthWebServer = serviceProvider.GetService<IHealthWebServer>();
            var action = serviceProvider.GetService<IAction>();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            healthWebServer.Start();

            logger.LogInformation("Process started");
            action.Run();
            logger.LogInformation("Process ended");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging(configure => configure.AddSerilog())
                .AddSingleton<IHealthMonitor, HealthMonitor>()
                .AddSingleton<IHealthWebServer, HealthWebServer>()
                .AddSingleton<IAction, FakePoller>();
        }
    }
}
