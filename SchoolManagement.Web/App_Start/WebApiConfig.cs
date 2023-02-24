using Microsoft.AspNetCore.Cors;
using Microsoft.Owin.Security.OAuth;
using SchoolManagement.Web.Filters;
using Serilog;
using System;
using System.IO;
using System.Web.Http;

namespace SchoolManagement.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(Path.Combine(logPath, "schoolmanagement-.log"), rollingInterval: RollingInterval.Day, shared: true, flushToDiskInterval: TimeSpan.FromSeconds(1), outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            config.Filters.Add(new GlobalExceptionHandlerAttribute());

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MapHttpAttributeRoutes();
        }
    }
}
