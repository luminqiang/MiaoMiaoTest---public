using MiaoMiaoTest.FrameWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MiaoMiaoTest.WebApi
{
    public class ProgramBase
    {
        protected static IConfiguration GetConfiguration()
        {
            var basePath = AppContext.BaseDirectory;
            var configPath = Path.Combine(basePath, "Config");
            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.SetBasePath(basePath);

            configurationBuilder.AddJsonFile("hosting.json", optional: true, reloadOnChange: true)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile("Config/log.json", optional: false, reloadOnChange: true); //其他配置文件

            configurationBuilder.AddXmlFile(b => { b.Path = "ConnectionStrings.config"; b.FileProvider = new PhysicalFileProvider(configPath); })
                                .AddXmlFile(b => { b.Path = "DomainSwitch.config"; b.FileProvider = new PhysicalFileProvider(configPath); });

            return configurationBuilder.Build();
        }
    }

    internal static class RegisterLifetimeEvents
    {
        private static readonly string appCode = AppSettingsReader.GetString("AppCode");
        private static readonly string appName = AppSettingsReader.GetString("AppName");
        private static readonly string iPV4Address;
        private static readonly string iPV6Address;

        static RegisterLifetimeEvents()
        {
            var interNetworkV6 = AddressFamily.InterNetworkV6;
            var interNetwork = AddressFamily.InterNetwork;
            var ipList = NetworkInterface.GetAllNetworkInterfaces()
                .Select(p => p.GetIPProperties())
                .SelectMany(p => p.UnicastAddresses)
                .Where(p => (p.Address.AddressFamily == interNetwork || p.Address.AddressFamily == interNetworkV6) && !System.Net.IPAddress.IsLoopback(p.Address)).ToList();

            iPV4Address = ipList[1]?.Address.ToString();
            iPV6Address = ipList[0]?.Address.ToString();
        }

        /// <summary>
        /// 注册应用程序生命周期事件
        /// </summary>
        public static void RegisterApplicationLifetimeEvents(this IHost host)
        {
            var hostApplicationLifetime = host.Services.GetService<IHostApplicationLifetime>();
            hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
            hostApplicationLifetime.ApplicationStopped.Register(OnStopped);
        }

        private static void OnStarted()
        {
            Console.WriteLine($"OnStarted has been called：{appCode} {appName} {DateTime.Now} {iPV4Address} {iPV6Address}");
            //Logger.Info($"OnStarted has been called：{appCode} {appName} {DateTime.Now} {iPV4Address} {iPV6Address}");
        }

        private static void OnStopping()
        {
            Console.WriteLine($"OnStopping has been called：{appCode} {appName} {DateTime.Now} {iPV4Address} {iPV6Address}");
            //Logger.Info($"OnStopping has been called：{appCode} {appName} {DateTime.Now} {iPV4Address} {iPV6Address}");
        }

        private static void OnStopped()
        {
            Console.WriteLine($"OnStopped has been called：{appCode} {appName} {DateTime.Now} {iPV4Address} {iPV6Address}");
            //Logger.Info($"OnStopped has been called：{appCode} {appName} {DateTime.Now} {iPV4Address} {iPV6Address}");
        }
    }
}
