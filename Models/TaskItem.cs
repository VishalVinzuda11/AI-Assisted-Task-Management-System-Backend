using System.ComponentModel.DataAnnotations;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string Description { get; set; } = string.Empty;

    public int Priority { get; set; }

    public TaskStatus Status { get; set; } = TaskStatus.New;

    public string AssignedTo { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
