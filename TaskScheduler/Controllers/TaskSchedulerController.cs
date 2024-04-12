using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskSchedulerController : ControllerBase
    {
        [HttpPost("Enqueue")]
        public IActionResult Enqueue()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine($"Enqueue at {DateTime.Now}"));
            return Ok();
        }
        
        [HttpPost("Delayed")]
        public IActionResult Delayed()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine($"Delayed at {DateTime.Now}"), TimeSpan.FromSeconds(10));
            return Ok();
        }

        [HttpPost("Recurring")]
        public IActionResult Recurring()
        {
            RecurringJob.AddOrUpdate("my recurring job", () => Console.WriteLine($"Recurring at {DateTime.Now}"), Cron.Minutely);
            return Ok();
        }

        [HttpPost("RecurringInterval")]
        public IActionResult RecurringInterval()
        {
            RecurringJob.AddOrUpdate("my recurring interval job", () => Console.WriteLine($"Recurring interval at {DateTime.Now}"), "5-6 0-0 0 ? * *");
            return Ok();
        }
    }
}
