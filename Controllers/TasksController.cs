using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/tasks
    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _context.Tasks
            .Where(t => !t.IsDeleted)
            .ToListAsync();
        return Ok(tasks);
    }

    // GET: api/tasks/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null || task.IsDeleted)
            return NotFound();
        return Ok(task);
    }

    // POST: api/tasks
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItemDTO dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            AssignedTo = dto.AssignedTo,
            DueDate = dto.DueDate,
            Status = TaskStatus.New,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT: api/tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItemDTO dto)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null || task.IsDeleted)
            return NotFound();

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Priority = dto.Priority;
        task.AssignedTo = dto.AssignedTo;
        task.DueDate = dto.DueDate;

        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }

    // PATCH: api/tasks/{id}/status
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromQuery] TaskStatus newStatus)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null || task.IsDeleted)
            return NotFound();

        if (newStatus < task.Status || (newStatus - task.Status) > 1)
            return BadRequest("Invalid status transition");

        task.Status = newStatus;
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }


    // DELETE: api/tasks/{id} (soft delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null || task.IsDeleted)
            return NotFound();

        task.IsDeleted = true;
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // GET: api/tasks/dashboard
    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        var total = await _context.Tasks.CountAsync(t => !t.IsDeleted);
        var completed = await _context.Tasks.CountAsync(t => t.Status == TaskStatus.Completed && !t.IsDeleted);
        var pending = total - completed;

        return Ok(new
        {
            TotalTasks = total,
            CompletedTasks = completed,
            PendingTasks = pending
        });
    }
}
