using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Worker.ConsoleApp
{
    public static class Startup
    {


        public static ServiceProvider ConfigureServices()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables();

            IConfiguration config = builder.Build();

            var _serviceProvider = new ServiceCollection()
                    .Configure<Settings>(options => config.GetSection("Settings").Bind(options))
                    .AddLogging()
                    .AddTransient<TesteFila>()
                    .BuildServiceProvider();


            return _serviceProvider;
        }
    }
}