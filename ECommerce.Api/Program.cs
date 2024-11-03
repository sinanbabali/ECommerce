
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ECommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information() // Log seviyesi
           .WriteTo.Console()          // Konsola yaz
           .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // Günlük dosyasýna yaz
           .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            // Apply database migrations
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
                dbContext.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}