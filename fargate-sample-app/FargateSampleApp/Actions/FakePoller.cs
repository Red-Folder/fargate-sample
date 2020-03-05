using FargateSampleApp.Health;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace FargateSampleApp.Actions
{
    public class FakePoller : IAction
    {
        private readonly IHealthMonitor _health;
        private readonly ILogger<FakePoller> _logger;

        public FakePoller(IHealthMonitor health, ILogger<FakePoller> logger)
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
                    _logger.LogInformation("Simulating a crash");
                    throw new Exception("Something broke");
                case 2:
                    _logger.LogInformation("Simulating a hang - going to sleep for 2 minutes");
                    Thread.Sleep(2 * 60 * 1000);
                    break;
                default:
                    _logger.LogInformation("Working ok");
                    break;
            }
        }
    }
}
