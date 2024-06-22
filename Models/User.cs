namespace WebApplication1.Models;

public class User
{
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Taskk> ReportedTasks { get; set; }
    public ICollection<Taskk> AssignedTasks { get; set; }
    public ICollection<Access> Accesses { get; set; }
}