using Application.Contracts;
using ConferenceApplicationSystem;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Application.Models.Application> Applications { get; set; }



    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ApplicationConfiguration());
        base.OnModelCreating(builder);
    }
}