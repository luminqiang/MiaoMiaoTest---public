using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MiaoMiaoTest.Common
{
    public class HtmlHelper
    {
        //public static HtmlDocument GetHtmlDocument(string url)
        //{
        //    var html = GetHtmlString(url);
        //    var htmlDoc = new HtmlDocument().Load();
        //    htmlDoc.LoadHtml(html);
        //    return htmlDoc;
        //}

        /// <summary>
        /// 返回特定编码格式的HTML内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encodeType"></param>
        /// <returns></returns>
        public static string GetHtmlByUrl(string url, string encodeType = "GB2312")
        {
            //先执行这个，不然使用GB2312报错
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                WebRequest wRequest = WebRequest.Create(url);
                wRequest.ContentType = $"text/html; charset={encodeType}";
                wRequest.Method = "get";
                wRequest.UseDefaultCredentials = true;
                // 获取Url返回html信息
                var task = wRequest.GetResponseAsync();
                WebResponse wResp = task.Result;
                Stream respStream = wResp.GetResponseStream();
                //使用对应编码读取
                using (StreamReader reader = new StreamReader(respStream, Encoding.GetEncoding(encodeType)))
                {
                    return HttpUtility.HtmlDecode(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// 使用HttpClient请求HTML数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetHtmlString(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(5000);
                    httpClient.DefaultRequestHeaders.Add("User-Agent", GetUserAgentRandom());
                    return httpClient.GetStringAsync(url).Result;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获得一个随机的Agent
        /// </summary>
        /// <returns></returns>
        private static string GetUserAgentRandom()
        {
            List<string> agentList = new List<string>
            {
                //Opera
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 OPR/26.0.1656.60",
                "Opera/8.0 (Windows NT 5.1; U; en)",
                "Mozilla/5.0 (Windows NT 5.1; U; en; rv:1.8.1) Gecko/20061208 Firefox/2.0.0 Opera 9.50",
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.50",
                //Firefox
                "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:34.0) Gecko/20100101 Firefox/34.0",
                "Mozilla/5.0 (X11; U; Linux x86_64; zh-CN; rv:1.9.2.10) Gecko/20100922 Ubuntu/10.10 (maverick) Firefox/3.6.10",
                //Safari
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.57.2 (KHTML, like Gecko) Version/5.1.7 Safari/534.57.2",
                //Chrome
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36",
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11",
                "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.16 (KHTML, like Gecko) Chrome/10.0.648.133 Safari/534.16",
                //360
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko",
                //淘宝浏览器
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.11 TaoBrowser/2.0 Safari/536.11",
                //猎豹浏览器
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.71 Safari/537.1 LBBROWSER",
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; LBBROWSER)",
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 732; .NET4.0C; .NET4.0E; LBBROWSER)",
                //QQ浏览器
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; QQBrowser/7.0.3698.400)",
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 732; .NET4.0C; .NET4.0E)",
                //SouGou浏览器
                "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.84 Safari/535.11 SE 2.X MetaSr 1.0",
                "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; SV1; QQDownload 732; .NET4.0C; .NET4.0E; SE 2.X MetaSr 1.0)",
                //Maxthon浏览器
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Maxthon/4.4.3.4000 Chrome/30.0.1599.101 Safari/537.36",
                //UC浏览器
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 UBrowser/4.0.3214.0 Safari/537.36"
            };
            int index = new Random().Next(0, agentList.Count - 1);
            return agentList[index];
        }

        /// <summary>
        /// 获取一个随机的线程休眠时间
        /// </summary>
        /// <returns></returns>
        private static int GetThreadSleepTimeRandom(int minValue = 1000, int maxValue = 3000)
        {
            return new Random().Next(minValue, maxValue);
        }
    }
}