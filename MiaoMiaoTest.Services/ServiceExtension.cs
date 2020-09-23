using MiaoMiaoTest.Services.PullData;
using MiaoMiaoTest.Services.WebApi;
//using MiaoMiaoTest.Services.WebApi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IXinCePingService, XinCePingService>()
                    .AddScoped<IMaoDouService, MaoDouService>();

            return services;
        }
    }
}
