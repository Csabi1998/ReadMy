using Domain.Entities;
using Infrastructure.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ReadMyDbContext : IdentityDbContext<ReadMyUser>
{
    public ReadMyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskunitConfiguration());
        modelBuilder.ApplyConfiguration(new LogConfiguration());
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Taskunit> Taskunits { get; set; }
    public DbSet<Log> Logs { get; set; }

}
