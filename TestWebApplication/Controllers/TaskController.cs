using Microsoft.AspNetCore.Mvc;
using TestWebApplication.AppDbContext;
using TestWebApplication.Models;
using TestWebApplication.Models.ModelsRequest;
using Task = TestWebApplication.Models.Task;

namespace TestWebApplication
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext taskDbContext;

        public TaskController(TaskDbContext taskDbContext)
        {
            this.taskDbContext = taskDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskRequest taskRequest)
        {
            await taskDbContext.AddAsync(new TestWebApplication.Models.Task(taskRequest.title, taskRequest.summary,
                taskRequest.started, taskRequest.finished)).ConfigureAwait(false);

            await taskDbContext.SaveChangesAsync().ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            Guid.TryParse("a36dc5bd-f028-4a9f-aa1c-3c002e759fb7", out var resultGuid);
            
            var result = taskDbContext.tasks
                .Where(w => w.Id !=  resultGuid)
                .ToArray();
            return Ok(result);
        }
    }
}