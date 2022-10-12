using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        builder.Property(x => x.CreationDate);
        builder.Property(x => x.Description);
        builder.HasMany(x => x.Participants)
            .WithMany(u => u.Projects);
        builder.HasOne(x => x.Creator)
            .WithMany(u => u.CreatorProjects)
            .HasForeignKey(k => k.CreatorId);
        builder.HasMany(x => x.Tasks)
            .WithOne(x => x.Project);
    }
}