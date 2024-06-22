namespace WebApplication1.Models.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ProjectId { get; set; }
    public UserDto Reporter { get; set; }
    public UserDto Assignee { get; set; }
}