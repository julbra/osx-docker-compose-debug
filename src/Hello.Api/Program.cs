using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Hello.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
        }


        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .ConfigureAppConfiguration((builderContext, config) =>
                                                     {
                                                         var env = builderContext.HostingEnvironment;
                                                         config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                               .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                                                                            optional: true,
                                                                            reloadOnChange: true)
                                                               .AddEnvironmentVariables();
                                                     })
                          .ConfigureLogging(logging =>
                                            {
                                                logging.ClearProviders();
                                                logging.SetMinimumLevel(LogLevel.Trace);
                                            })
                          .UseNLog()
                          .Build();
        }
    }
}