using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.FrameWork
{
    public class FrameWorkUtil
    {
        public static readonly FrameWorkUtil Instance = new FrameWorkUtil();

        private FrameWorkUtil()
        {
        }

        public IServiceProvider ServiceProvider { get; internal set; }

        public ILoggerFactory LoggerFactory { get; internal set; }

        public IConfiguration Configuration { get; internal set; }

        public IHostingEnvironment HostingEnvironment { get; internal set; }
    }
}
