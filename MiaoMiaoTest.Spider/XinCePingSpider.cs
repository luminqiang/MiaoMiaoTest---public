using MiaoMiaoTest.Common.Helpers;
using MiaoMiaoTest.Config.Enums;
using MiaoMiaoTest.Models.Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiaoMiaoTest.Spider
{
    public class XinCePingSpider : SpiderBase
    {
        public static (List<Test> tests, List<TestErrorJob> errorJobs) Take(string url, ClassifyIdEnum classifyId)
        {
            var chromeDriver = GetChromeDriver(url, true);
            var webElements = chromeDriver.FindElementsByClassName("post-style-card");

            var dateTimeNow = DateTime.Now;
            var tests = new List<Test>();
            var errorJobs = new List<TestErrorJob>();

            foreach (var item in webElements)
            {
                var test = new Test();
                try
                {
                    var detailUrl = item.FindElement(By.XPath("./a")).GetAttribute("href");
                    
                    test.Title = item.FindElement(By.ClassName("post-title"))?.Text;
                    //test.SmallImage = item.FindElement(By.XPath("./a")).GetAttribute("style").Split('"')[1];
                    test.LabelName = item.FindElement(By.XPath("./div[1]/div[2]/span[1]/a")).Text;
                    test.Time = item.FindElement(By.ClassName("post-time")).Text;
                    test.LikeCount = int.Parse(item.FindElement(By.XPath("./div[2]/ul/li[4]/span")).Text);
                    test.ViewCount = int.Parse(item.FindElement(By.XPath("./div[2]/ul/li[2]")).Text.Trim());
                    test.CreateTime = dateTimeNow;
                    test.CreateUnixTime = DateTimeHelper.GetUnixTimestamp(dateTimeNow);
                    test.OtherId = long.Parse(detailUrl.Split('/').Last());
                    test.SourceId = (int)SourceIdEnum.心评测;
                    test.SourceName = SourceIdEnum.心评测.ToString();
                    test.TypeId = (int)classifyId;
                    test.TypeName = classifyId.ToString();
                    test.UnixTime = DateTimeHelper.GetUnixTimestamp(DateTime.Parse(test.Time));

                    //获取详细信息
                    chromeDriver.ExecuteScript("window.open()");
                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[chromeDriver.WindowHandles.Count - 1]);
                    chromeDriver.Navigate().GoToUrl(detailUrl);

                    test.BigImage = chromeDriver.FindElementByXPath("//*[@class='article-img']/img").GetAttribute("src");
                    test.SmallImage = test.BigImage;
                    test.Content = chromeDriver.FindElementByXPath("//*[@class='article-body']/p[1]").Text;
                    test.TestCount = test.ViewCount / 4;

                    #region 获取测试标签

                    var testLabels = new List<TestLabel>();
                    var testLabelElements = chromeDriver.FindElementsByXPath("/html/body/main/div/div[1]/div/article/div[3]/div/a");
                    foreach (var labelItem in testLabelElements)
                    {
                        testLabels.Add(new TestLabel()
                        {
                            Label = labelItem.Text
                        });
                    }

                    test.TestLabels = testLabels;

                    #endregion 获取测试标签

                    #region 测试题目和选项及答案

                    var testTitles = new List<TestTitle>();

                    var titleUrl = chromeDriver.FindElementByXPath("/html/body/main/div/div[1]/div/article/div[4]/p[2]/a").GetAttribute("href");
                    chromeDriver.Url = titleUrl;
                    var testTitleElements = chromeDriver.FindElementsById("question_box");
                    foreach (var titleItem in testTitleElements)
                    {
                        var testOptionElemens = chromeDriver.FindElementsByClassName("icheckbox_div");
                        var testOptions = new List<TestOption>();
                        var testAnswers = new List<TestAnswer>();

                        var nextOptionIndex = 0;
                        for (int optionIndex = 0; optionIndex < testOptionElemens.Count; optionIndex++)
                        {
                            //在新标签页打开题目页面，防止刷新页面后元素失效
                            chromeDriver.ExecuteScript("window.open()");
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[chromeDriver.WindowHandles.Count - 1]);
                            chromeDriver.Navigate().GoToUrl(titleUrl);

                            var newTestOptionElemens = chromeDriver.FindElementsByClassName("icheckbox_div");
                            testOptions.Add(new TestOption()
                            {
                                FlagId = nextOptionIndex,
                                Option = newTestOptionElemens[optionIndex].FindElement(By.XPath("./label")).Text
                            });

                            newTestOptionElemens[optionIndex].FindElement(By.XPath("./span/a")).Click();
                            chromeDriver.FindElement(By.Id("next_button")).Click();

                            var answer = string.Empty;
                            try
                            {
                                answer = chromeDriver.FindElementByXPath("//*[@id='end_desc']/p/span").Text;
                            }
                            catch (NoSuchElementException ex)
                            {
                                answer = chromeDriver.FindElementByXPath("//*[@id='end_desc']/p").Text;
                            }

                            testAnswers.Add(new TestAnswer
                            {
                                FlagId = nextOptionIndex,
                                Answer = answer
                            });

                            chromeDriver.ExecuteScript("window.close()");
                            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[chromeDriver.WindowHandles.Count - 1]);
                            nextOptionIndex++;
                        }

                        testTitles.Add(new TestTitle()
                        {
                            Title = titleItem.FindElement(By.XPath("./div[2]/div[1]")).Text,
                            TestOptions = testOptions,
                            TestAnswers = testAnswers
                        });
                    }

                    test.TestTitles = testTitles;

                    #endregion 测试题目和选项及答案

                    tests.Add(test);

                    chromeDriver.Close();
                    chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                }
                catch (Exception ex)
                {
                    errorJobs.Add(new TestErrorJob()
                    {
                        Url = url,
                        ExceptionMessage = ex.Message,
                        ExceptionStackInfo = ex.StackTrace,
                        CreateTime = dateTimeNow,
                        CreateUnixTime = DateTimeHelper.GetUnixTimestamp(dateTimeNow),
                        OtherId = test?.OtherId ?? 0,
                        SourceId = (int)SourceIdEnum.心评测,
                        SourceName = SourceIdEnum.心评测.ToString(),
                        TypeId = (int)classifyId,
                        TypeName = classifyId.ToString()
                    });
                    continue;
                }
            }

            chromeDriver.Quit();
            return (tests, errorJobs);
        }
    }
}