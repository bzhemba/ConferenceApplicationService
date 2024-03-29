using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IApplicationDbContext
{
    DbSet<Models.Application> applications { get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}