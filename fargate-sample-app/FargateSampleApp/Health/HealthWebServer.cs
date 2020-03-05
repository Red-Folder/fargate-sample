using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace FargateSampleApp.Health
{
    public class HealthWebServer : IHealthWebServer
    {
        private readonly IHealthMonitor _health;

        public HealthWebServer(IHealthMonitor health)
        {
            _health = health;
        }

        public Task Start()
        {
            return WebHost
                .CreateDefaultBuilder()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 8100);
                })
                .ConfigureServices(servicesCollection =>
                {
                    servicesCollection.AddSingleton(_health);
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                })
                .UseStartup<HealthStartup>()
                .Build()
                .RunAsync();
        }
    }
}
