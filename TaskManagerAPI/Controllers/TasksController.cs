using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;
using TaskManagerAPI.DTOs;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TasksController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _context.Tasks
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsCompleted = t.IsCompleted
                })
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            var task = new TaskItem
            {
                Title = createTaskDto.Title,
                IsCompleted = false
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            var taskDto = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };

            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, taskDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}