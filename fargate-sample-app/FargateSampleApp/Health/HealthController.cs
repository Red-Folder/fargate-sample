using Microsoft.AspNetCore.Mvc;

namespace FargateSampleApp.Health
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthMonitor _health;

        public HealthController(IHealthMonitor health)
        {
            _health = health;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return _health.Healthy ? Ok() : StatusCode(500);
        }
    }
}
