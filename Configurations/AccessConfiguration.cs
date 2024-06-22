using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations;

public class AccessConfiguration : IEntityTypeConfiguration<Access>
{
    public void Configure(EntityTypeBuilder<Access> builder)
    {
        builder.HasKey(a => new { a.IdProject, a.IdUser });

        builder.HasOne(a => a.Project)
            .WithMany(p => p.Accesses)
            .HasForeignKey(a => a.IdProject);

        builder.HasOne(a => a.User)
            .WithMany(u => u.Accesses)
            .HasForeignKey(a => a.IdUser);
    }
}