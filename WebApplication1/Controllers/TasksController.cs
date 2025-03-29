using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class TasksController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Hacer la compra", Status = "Pendiente" },
            new TaskItem { Id = 2, Title = "Estudiar .NET", Status = "Completada" }
        };

        // GET /tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks()
        {
            return Ok(tasks);
        }
}