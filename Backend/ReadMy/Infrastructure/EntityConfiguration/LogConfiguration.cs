using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type);
        builder.Property(x => x.WorkingHours);
        builder.HasOne(x => x.Creator)
            .WithMany(u => u.Logs)
            .HasForeignKey(k => k.CreatorId);
        builder.Property(x => x.Description);
        builder.Property(x => x.Name);
        builder.HasOne(x => x.Task)
            .WithMany(t => t.Logs)
            .HasForeignKey(k => k.TaskId);
    }
}