using MiaoMiaoTest.FrameWork;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Common.Helpers
{
    public static class HttpClientHelper
    {
        private static readonly IHttpClientFactory _httpClientFactory;

        static HttpClientHelper()
        {
            _httpClientFactory = IocManager.GetService<IHttpClientFactory>();
        }

        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
        {
            Error = delegate (object se, ErrorEventArgs ev)
            {
                ev.ErrorContext.Handled = true;
            }
        };

        private static HttpRequestMessage GetHttpRequestMessageForGet(string path, Dictionary<string, string> paramDic, Dictionary<string, string> headerDic = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path必须提供");
            }

            if (paramDic != null && paramDic.Any())
            {
                var paramList = new List<string>();
                foreach (var item in paramDic)
                {
                    paramList = paramDic.Select(m => $"{m.Key}={m.Value}").ToList();
                }

                path = string.Concat(path, "?", string.Join("&", paramList));
            }

            var request = new HttpRequestMessage(HttpMethod.Get, path);

            if (headerDic != null && headerDic.Any())
            {
                foreach (var item in headerDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            return request;
        }

        private static HttpRequestMessage GetHttpRequestMessageForPost(string path, object param, Dictionary<string, string> headerDic = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path必须提供");
            }

            var request = new HttpRequestMessage(HttpMethod.Post, path);

            if (param != null)
            {
                var paramJsonStr = JsonConvert.SerializeObject(param);
                request.Content = new StringContent(paramJsonStr, Encoding.UTF8, "application/json");
            }

            if (headerDic != null && headerDic.Any())
            {
                foreach (var item in headerDic)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }

            return request;
        }

        /// <summary>
        /// 同步Get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainName"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="paramDic"></param>
        /// <param name="headerDic"></param>
        /// <returns></returns>
        public static T Get<T>(string domainName, string domain, string path, Dictionary<string, string> paramDic, Dictionary<string, string> headerDic = null)
        {
            return GetAsync<T>(domainName, domain, path, paramDic, headerDic).Result;
        }

        /// <summary>
        /// 同步Get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainName"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="paramDic"></param>
        /// <param name="headerDic"></param>
        /// <returns></returns>
        public static T Get<T>(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url不能为空");
            }

            var httpClient = _httpClientFactory.CreateClient("Dafault");
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = httpClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseString, jsonSerializerSettings);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 异步Get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainName"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="paramDic"></param>
        /// <param name="headerDic"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string domainName, string domain, string path, Dictionary<string, string> paramDic, Dictionary<string, string> headerDic = null)
        {
            var httpClient = _httpClientFactory.CreateClient(domainName);
            if (httpClient.BaseAddress == null)
            {
                httpClient.BaseAddress = new Uri(domain);
            }

            var request = GetHttpRequestMessageForGet(path, paramDic, headerDic);
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString, jsonSerializerSettings);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 异步POST请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainName"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="param"></param>
        /// <param name="headerDic"></param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string domainName, string domain, string path, object param, Dictionary<string, string> headerDic = null)
        {
            var httpClient = _httpClientFactory.CreateClient(domainName);
            if (httpClient.BaseAddress == null)
            {
                httpClient.BaseAddress = new Uri(domain);
            }

            var request = GetHttpRequestMessageForPost(path, param, headerDic);
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString, jsonSerializerSettings);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 同步POST请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainName"></param>
        /// <param name="domain"></param>
        /// <param name="path"></param>
        /// <param name="param"></param>
        /// <param name="headerDic"></param>
        /// <returns></returns>
        public static T Post<T>(string domainName, string domain, string path, object param, Dictionary<string, string> headerDic = null)
        {
            return PostAsync<T>(domainName, domain, path, param, headerDic).Result;
        }
    }
}