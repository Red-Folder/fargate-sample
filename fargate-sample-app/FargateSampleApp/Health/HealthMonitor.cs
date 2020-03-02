using System;

namespace FargateSampleApp.Health
{
    public class HealthMonitor
    {
        private const int THRESHOLD_IN_SECONDS = 10;
        private bool _monitoring = false;
        private DateTime _lastHeartbeat = DateTime.Now;

        private readonly object _lock = new object();

        public void StartMonitoring()
        {
            lock (_lock)
            {
                _monitoring = true;
                _lastHeartbeat = DateTime.Now;
            }
        }

        public void Checkin()
        {
            lock(_lock)
            {
                _lastHeartbeat = DateTime.Now;
            }
        }

        public bool Healthy
        {
            get
            {
                var healthy = true;
                lock(_lock)
                {
                    if (_monitoring)
                    {
                        healthy = (DateTime.Now - _lastHeartbeat).Seconds < THRESHOLD_IN_SECONDS;
                    }
                }
                return healthy;
            }
        }
    }
}
