using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace WolfPeopleKill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, config) =>
                    {
                        var settings = config.Build();
                        var appConfigurationConnectionString = settings["AzureAppConfiguration:ConnectionString"];
                    });



                    webBuilder.UseStartup<Startup>();
                });
    }
}
