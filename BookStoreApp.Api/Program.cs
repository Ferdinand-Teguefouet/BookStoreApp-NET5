using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Test logger

            //Configuration of logger object when using Serilog
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.File(path: "d:\\log-.txt",
            //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]{Message:lj}{NewLine}{Exception}",
            //    rollingInterval: RollingInterval.Day,
            //    restrictedToMinimumLevel: LogEventLevel.Information
            //    ).CreateLogger();
            //try
            //{
            //    Log.Information("Application is starting!");
            //    CreateHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Application Failed Starting");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //} 
            #endregion

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)) // Serilog
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
