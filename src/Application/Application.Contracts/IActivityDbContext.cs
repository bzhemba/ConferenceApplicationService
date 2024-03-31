using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IActivityDbContext
{
    DbSet<Activity> Activities { get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}