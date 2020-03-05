namespace FargateSampleApp.Health
{
    public interface IHealthMonitor
    {
        bool Healthy { get; }

        void Checkin();
        void StartMonitoring();
    }
}