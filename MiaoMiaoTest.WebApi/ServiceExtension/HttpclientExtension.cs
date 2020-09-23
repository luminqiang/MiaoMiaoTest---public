using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace MiaoMiaoTest.WebApi.ServiceExtension
{
    public static class HttpclientExtension
    {
        /// <summary>
        /// 配置命名HttpClient
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpClientByName(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddHttpClient("Default", c =>
            {
                c.Timeout = TimeSpan.FromSeconds(120);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                c.DefaultRequestHeaders.Add("Connection", "keep-alive");
            }).ConfigurePrimaryHttpMessageHandler(GetDefaultHttpClientHandler);

            return services;
        }

        /// <summary>
        /// 默认通用 HttpClientHandler
        /// </summary>
        /// <returns></returns>
        private static HttpClientHandler GetDefaultHttpClientHandler()
        {
            return new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                UseDefaultCredentials = true,
                Proxy = null,
                UseProxy = false,
                UseCookies = false //禁用自动Cookie处理
            };
        }
    }
}