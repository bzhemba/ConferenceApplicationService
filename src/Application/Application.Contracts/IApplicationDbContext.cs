using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IApplicationDbContext
{
    DbSet<Models.Application> Applications { get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}