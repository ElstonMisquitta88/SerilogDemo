using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // [+] SeriLog Changes
            // Configuring the Serilog settings via the appsetting.json file

            // STEP 1
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // STEP 2 -- Manage Nuget Packages
            // (a) Serilog.aspnetcore
            // (b) Serilog.settings.configuration
            // (c) Serilog.Enrichers.Environment
            // (d) Serilog.Enrichers.Thread
            // (e) Serilog.Enrichers.Process

            // STEP 3  -- (SeriLog)
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

            try
            {
                Log.Information("Application Starting Up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.ToString(), "App Failed to Start Correctly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            // [-] SeriLog Changes

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // [+] SeriLog Changes
                .UseSerilog() // STEP 4
                // [-] SeriLog Changes
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
