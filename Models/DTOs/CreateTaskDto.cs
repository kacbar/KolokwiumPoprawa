namespace WebApplication1.Models.DTOs;

public class CreateTaskDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int ReporterId { get; set; }
    public int? AssigneeId { get; set; }
}