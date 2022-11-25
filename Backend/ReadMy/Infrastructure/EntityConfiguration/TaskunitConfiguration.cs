using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;

public class TaskunitConfiguration : IEntityTypeConfiguration<Taskunit>
{
    public void Configure(EntityTypeBuilder<Taskunit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SerialNumber);
        builder.Property(x => x.Type);
        builder.Property(x => x.Description);
        builder.Property(x => x.CreationDate);
        builder.Property(x => x.Name);
        builder.HasOne(x => x.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(k => k.ProjectId);
        builder.HasMany(x => x.Logs)
            .WithOne(l => l.Task);
    }
}