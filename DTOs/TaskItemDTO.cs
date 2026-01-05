public class TaskItemDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public int Priority { get; set; }
    public string AssignedTo { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
}
