namespace Application.Infrastructure.DataAccess;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context, ActivityDbContext activityDbContext)
    {
        context.Database.EnsureCreated();
        activityDbContext.Database.EnsureCreated();
    }
}