using System;
using System.IO;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Click360.API.Config;

namespace Click360.API
{
    /// <summary>
    /// The <see cref="Program"/> class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Working directory the application launched from
        /// </summary>
        public static string WorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// .NET Configuration Service
        /// </summary>
        public static IConfiguration Configuration => new ConfigurationBuilder()
                .SetBasePath(WorkingDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

        /// <summary>
        /// The application entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            SerilogConfig.Configure(serviceCollection, Configuration);

            try
            {
                Log.Verbose("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Application start-up failed. Error Reason: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// The host builder for creating the kestrel instance
        /// </summary>
        /// <param name="args"></param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(Configuration);
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
