using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>
        //TASK DE OPCIONES
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
        // GET /tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound(new { message = "Tarea no encontrada" });
            return Ok(task);
        }

        // POST /tasks
        [HttpPost]
        public ActionResult<TaskItem> CreateTask(TaskItem task)
        {
            task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        // PUT /tasks/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound(new { message = "Tarea no encontrada" });

            task.Title = updatedTask.Title;
            task.Status = updatedTask.Status;
            return NoContent();
        }

        // DELETE /tasks/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound(new { message = "Tarea no encontrada" });

            tasks.Remove(task);
            return NoContent();

        }
    }