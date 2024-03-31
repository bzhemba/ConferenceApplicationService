using Application.Infrastructure.DataAccess;
using ConferenceApplicationSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var applicationContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                var activityContext = serviceProvider.GetRequiredService<ActivityDbContext>();
                DbInitializer.Initialize(applicationContext, activityContext);
            }
            catch (Exception exception)
            { 
            }
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}