using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns>List of all tasks</returns>
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(tasks);
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="task">The task to create</param>
        /// <returns>The created task with assigned ID</returns>
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task?.Title))
            {
                return BadRequest("Task title is required.");
            }

            task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }
    }
}