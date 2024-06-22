using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.IdUser);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);  // Dostosowane ograniczenie
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);  // Dostosowane ograniczenie

        builder.HasMany(u => u.ReportedTasks)
            .WithOne(t => t.Reporter)
            .HasForeignKey(t => t.IdReporter)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.AssignedTasks)
            .WithOne(t => t.Assignee)
            .HasForeignKey(t => t.IdAssignee)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Accesses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.IdUser);
    }
}