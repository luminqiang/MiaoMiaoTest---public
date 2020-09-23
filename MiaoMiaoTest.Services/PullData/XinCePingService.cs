using MiaoMiaoTest.Config.Enums;
using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;
using MiaoMiaoTest.Spider;
using System.Linq;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Services.PullData
{
    public class XinCePingService : IXinCePingService
    {
        private readonly string _characterDataUrl = "http://www.xinceping.cn/topics/character/page/";
        private readonly string _loveDateUrl = "http://www.xinceping.cn/topics/love/page/";
        private readonly string _tasteDateUrl = "http://www.xinceping.cn/topics/taste/page/";
        private readonly ITestRepository _testRepository;
        private readonly ITestTitleRepository _testTitleRepository;
        private readonly ITestAnswerRepository _testAnswerRepository;
        private readonly ITestLabelRepository _testLabelRepository;
        private readonly ITestOptionRepository _testOptionRepository;
        private readonly ITestErrorJobRepository _testErrorJobRepository; 

        public XinCePingService(ITestRepository testRepository, ITestTitleRepository testTitleRepository,
            ITestAnswerRepository testAnswerRepository, ITestLabelRepository testLabelRepository,
            ITestOptionRepository testOptionRepository, ITestErrorJobRepository testErrorJobRepository)
        {
            _testRepository = testRepository;
            _testTitleRepository = testTitleRepository;
            _testAnswerRepository = testAnswerRepository;
            _testLabelRepository = testLabelRepository;
            _testOptionRepository = testOptionRepository;
            _testErrorJobRepository = testErrorJobRepository;
        }       

        public async Task<string> PullCharacterData(int pageStartIndex, int pageEndIndex)
        {
            return await PullData(pageStartIndex, pageEndIndex, _characterDataUrl, ClassifyIdEnum.心理测试);
        }

        public async Task<string> PullTasteData(int pageStartIndex, int pageEndIndex)
        {
            return await PullData(pageStartIndex, pageEndIndex, _tasteDateUrl, ClassifyIdEnum.趣味测试);
        }

        public async Task<string> PullLoveData(int pageStartIndex, int pageEndIndex)
        {
            return await PullData(pageStartIndex, pageEndIndex, _loveDateUrl, ClassifyIdEnum.爱情测试);
        }

        private async Task<string> PullData(int pageStartIndex, int pageEndIndex, string dataUrl, ClassifyIdEnum classifyId)
        {
            var successCount = 0;
            var errorCount = 0;
            for (int pageIndex = pageStartIndex; pageIndex <= pageEndIndex; pageIndex++)
            {
                var (tests, errorJobs) = XinCePingSpider.Take($"{dataUrl}{pageIndex}", classifyId);
                if (errorJobs != null && errorJobs.Any())
                {
                    errorCount += await _testErrorJobRepository.Add(errorJobs);
                }

                foreach (var item in tests)
                {
                    var isExist = await _testRepository.QueryAsQueryable(a => a.OtherId == item.OtherId && a.SourceId == (int)SourceIdEnum.心评测).AnyAsync();
                    if (isExist)
                    {
                        continue;
                    }

                    if (!CheckTest(item))
                    {
                        continue;
                    }

                    var testId = _testRepository.Add(item).Result;
                    SetTestId(item, testId);
                    var insertCount = await _testLabelRepository.Add(item.TestLabels);
                    foreach (var title in item.TestTitles)
                    {
                        var testTitleId = await _testTitleRepository.Add(title);
                        SetTestTitleId(title, testTitleId);

                        foreach (var option in title.TestOptions)
                        {
                            var optionId = await _testOptionRepository.Add(option);
                            var answer = title.TestAnswers.Where(a => a.FlagId == option.FlagId).FirstOrDefault();
                            SetTestOptionId(answer, optionId);
                            await _testAnswerRepository.Add(answer);
                        }
                    }
                    successCount += 1;
                }
            }

            return $"本次爬取页数为：{pageEndIndex - pageStartIndex} 成功采集数据：{successCount}条 异常采集：{errorCount}条";
        }

        private void SetTestId(Test test, long testId)
        {
            test.TestLabels.ForEach(a =>
            {
                a.TestId = testId;
            });

            test.TestTitles.ForEach(a =>
            {
                a.TestId = testId;
                a.TestAnswers.ForEach(b =>
                {
                    b.TestId = testId;
                });
                a.TestOptions.ForEach(c =>
                {
                    c.TestId = testId;
                });
            });
        }

        private void SetTestTitleId(TestTitle testTitle, long testTitleId)
        {
            testTitle.TestAnswers.ForEach(a =>
            {
                a.TestTitleId = testTitleId;
            });

            testTitle.TestOptions.ForEach(a =>
            {
                a.TestTitleId = testTitleId;
            });
        }

        private void SetTestOptionId(TestAnswer testAnswer, long testOptionId)
        {
            testAnswer.TestOptionId = testOptionId;
        }

        private bool CheckTest(Test test)
        {
            if (test == null) return false;
            if (test.TestLabels == null || !test.TestLabels.Any()) return false;
            if (test.TestTitles == null || !test.TestTitles.Any()) return false;
            foreach(var item in test.TestTitles)
            {
                if (item.TestOptions.Count != item.TestAnswers.Count) return false;
                if (item.TestAnswers == null || !item.TestAnswers.Any()) return false;
                if (item.TestOptions == null || !item.TestOptions.Any()) return false;
            }

            return true;
        }
    }
}