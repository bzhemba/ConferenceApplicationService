using ConferenceApplicationSystem;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.DataAccess;

public class ActivityDbContext : DbContext
{
    public DbSet<Application.Models.Application> Activities { get; set; }
    public ActivityDbContext(DbContextOptions<ActivityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ActivityConfiguration());
        base.OnModelCreating(builder);
    }
}