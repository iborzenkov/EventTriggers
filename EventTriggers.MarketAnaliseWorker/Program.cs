using EventTriggers.MarketAnaliseWorker.Models;
using EventTriggers.MarketAnaliseWorker.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace EventTriggers.MarketAnaliseWorker
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
                    var configuration = hostContext.Configuration;
                    services.Configure<DatabaseSettings>(
                        configuration.GetSection(nameof(DatabaseSettings)));
                    services.AddSingleton<IDatabaseSettings>(sp =>
                        sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

                    services.AddSingleton<EventTriggerService>();

                    services.AddHostedService<Worker>();
                });
    }
}