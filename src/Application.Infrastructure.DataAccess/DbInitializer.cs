using System.Net.Mime;
using Application.Infrastructure;
namespace Application.Infrastructure.DataAccess;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();
    }
}