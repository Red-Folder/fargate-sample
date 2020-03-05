using System.Threading.Tasks;

namespace FargateSampleApp.Health
{
    public interface IHealthWebServer
    {
        Task Start();
    }
}