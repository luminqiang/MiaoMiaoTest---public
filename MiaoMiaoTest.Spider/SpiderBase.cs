using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace MiaoMiaoTest.Spider
{
    public class SpiderBase
    {
        protected static ChromeDriver GetChromeDriver(string url, bool headLess = false)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("页面地址不能为空");
            }

            var chromeOptions = new ChromeOptions
            {
                LeaveBrowserRunning = true
            };

            if (headLess)
            {
                chromeOptions.AddArgument("--headless");
            }

            var chromeDriver = new ChromeDriver(Path.Combine(AppContext.BaseDirectory, "ChromeDriver"), chromeOptions)
            {
                Url = url
            };
            chromeDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(20);
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return chromeDriver;
        }
    }
}