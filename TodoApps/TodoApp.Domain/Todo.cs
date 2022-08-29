namespace TodoApp.Domain;

public class Todo
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime EndedAt { get; set; }
    public bool IsDone { get; set; } = false;
    public string Description { get; set; }
}