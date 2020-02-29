using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prepper.Service.Services;

namespace Prepper.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<PrepperService>();
                    services.AddHttpClient<IMovieDatabaseService>();
                    services.AddScoped<IMovieDatabaseService>();
                });
    }
}
