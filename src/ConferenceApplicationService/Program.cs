﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Infrastructure.DataAccess;

namespace ConferenceApplicationService;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception exception)
            {

            }
        }

        host.Run();
    }
    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}