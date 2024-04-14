using System.Reflection;
using Application.Contracts;
using Application.Infrastructure.DataAccess.Extensions;
using Applications.Mapping;
using ConferenceApplicationService.Application;
using ConferenceApplicationService.Application.Extensions;
using MediatR;

namespace ConferenceApplicationSystem;

public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(IActivityDbContext).Assembly));
        });

        services.AddApplication();
        services.AddInfrastructureDataAccess(Configuration);
        services.AddControllers();
        services.AddMediatR(typeof(ConferenceApplicationsServiceMediatREntryPoint).Assembly);

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}