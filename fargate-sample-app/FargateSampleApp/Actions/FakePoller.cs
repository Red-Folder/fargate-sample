using FargateSampleApp.Health;
using Serilog;
using System;
using System.Threading;

namespace FargateSampleApp.Actions
{
    public class FakePoller
    {
        private readonly HealthMonitor _health;
        private readonly ILogger _logger;

        public FakePoller(HealthMonitor health, ILogger logger)
        {
            _health = health;
            _logger = logger;
        }

        public void Run()
        {
            var random = new Random();

            _health.StartMonitoring();

            while (true)
            {
                var value = random.Next(0, 9);

                _logger.Information($"Received {value}");

                if (value == 0)
                {
                    _logger.Information("Going to sleep for 2 minutes to simulate hang");
                    Thread.Sleep(2 * 60 * 1000);
                }
                else
                {
                    Thread.Sleep(3 * 1000);
                }

                _health.Checkin();
            }
        }
    }
}
