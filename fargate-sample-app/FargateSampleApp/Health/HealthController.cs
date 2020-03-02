using Microsoft.AspNetCore.Mvc;

namespace FargateSampleApp.Health
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly HealthMonitor _health;

        public HealthController(HealthMonitor health)
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
