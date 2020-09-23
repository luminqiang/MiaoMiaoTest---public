using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace MiaoMiaoTest.FrameWork
{
    public static class FrameWorkConfig
    {
        public static FrameWorkUtil Configure(IServiceProvider serviceProvider, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            FrameWorkUtil.Instance.Configuration = configuration;
            FrameWorkUtil.Instance.ServiceProvider = serviceProvider;
            FrameWorkUtil.Instance.LoggerFactory = loggerFactory;
            return FrameWorkUtil.Instance;
        }

        public static FrameWorkUtil Configure(IServiceProvider serviceProvider, IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
        {
            Configure(serviceProvider, configuration, loggerFactory);
            FrameWorkUtil.Instance.HostingEnvironment = hostingEnvironment;
            return FrameWorkUtil.Instance;
        }
    }
}