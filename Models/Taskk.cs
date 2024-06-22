namespace WebApplication1.Models;

public class Taskk
{
    public int IdTask { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int IdProject { get; set; }
    public int IdReporter { get; set; }
    public int? IdAssignee { get; set; }

    public Project Project { get; set; }
    public User Reporter { get; set; }
    public User Assignee { get; set; }
}