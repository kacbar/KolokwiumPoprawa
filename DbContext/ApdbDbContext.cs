using Microsoft.EntityFrameworkCore;
using WebApplication1.Configurations;
using WebApplication1.Models;

namespace WebApplication1.AppDbContext;

public class ApdbDbContext : DbContext
{
    public ApdbDbContext() { }

    public ApdbDbContext(DbContextOptions<ApdbDbContext> options)
        : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Taskk> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Access> Accesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AccessConfiguration());
    }
}