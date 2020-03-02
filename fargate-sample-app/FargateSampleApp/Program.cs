using FargateSampleApp.Actions;
using FargateSampleApp.Health;
using Serilog;

namespace FargateSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var health = new HealthMonitor();
            var healthWebServer = new HealthWebServer(health);
            var poller = new FakePoller(health, logger);

            healthWebServer.Start();

            logger.Information("Process started");
            poller.Run();
            logger.Information("Process ended");
        }
    }
}
