using Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Models.Application> Applications { get; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ApplicationConfiguration());
        base.OnModelCreating(builder);
    }
}