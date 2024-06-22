namespace WebApplication1.Models;

public class Project
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    public int IdDefaultAssignee { get; set; }

    public ICollection<Taskk> Tasks { get; set; }
    public ICollection<Access> Accesses { get; set; }
}