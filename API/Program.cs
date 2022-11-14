using System;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        // Every project must have a Pogram.cs. This contains the 'main' method. The program flow starts here and runs the code in this method.
        public static void Main(string[] args)
        {
            //This line runs .net server used to host API
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Problem migrating data");
            }

            host.Run();
        }

        //What is Host Builder? Host Builder is a static class that provides two methods and when we call these methods, they will add some features into ASP.NET Core Applications. The Host Builder Provides two convenient methods for creating instances of IHostBuilder with pre-configured defaults.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
