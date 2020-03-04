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
                Thread.Sleep(3 * 1000);

                Action(random);

                _health.Checkin();
            }
        }

        private void Action(Random random)
        {
            var value = random.Next(1, 20);

            switch (value)
            {
                case 1:
                    _logger.Information("Simulating a crash");
                    throw new Exception("Something broke");
                case 2:
                    _logger.Information("Simulating a hang - going to sleep for 2 minutes");
                    Thread.Sleep(2 * 60 * 1000);
                    break;
                default:
                    _logger.Information("Working ok");
                    break;
            }
        }
    }
}
