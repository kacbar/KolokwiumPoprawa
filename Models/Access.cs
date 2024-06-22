namespace WebApplication1.Models;

public class Access
{
    public int IdProject { get; set; }
    public int IdUser { get; set; }

    public Project Project { get; set; }
    public User User { get; set; }
}