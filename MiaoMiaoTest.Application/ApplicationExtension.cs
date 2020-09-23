//using MiaoMiaoTest.Application.PullData;
//using MiaoMiaoTest.Application.WebAPi;
using MiaoMiaoTest.Application.PullData;
using MiaoMiaoTest.Application.WebApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IXinPingCeApplication, XinPingCeApplication>()
                    .AddScoped<IMaoDouApplication, MaoDouApplication>();

            return services;
        }
    }
}
