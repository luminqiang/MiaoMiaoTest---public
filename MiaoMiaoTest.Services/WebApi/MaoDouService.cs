using MiaoMiaoTest.Config.Enums;
using MiaoMiaoTest.Models.Input.MaoDou;
using MiaoMiaoTest.Models.Utility;
using MiaoMiaoTest.Models.Vo.MaoDouController;
using MiaoMiaoTest.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Services.WebApi
{
    public class MaoDouService : IMaoDouService
    {
        private readonly ITestRepository _testRepository;

        public MaoDouService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<VoIndexData> GetIndexDataAsync(InputOfIndexData input)
        {
            var carouselTests = await GetCarouselTests();
            var hotTests = await GetHotTests();
            var allTests = await GetAllTests(input);

            return new VoIndexData()
            {
                CarouselTests = carouselTests,
                HotTests = hotTests,
                AllTests = allTests
            };
        }

        /// <summary>
        /// 获取轮播测试题列表
        /// </summary>
        /// <returns></returns>
        private async Task<List<VoTest>> GetCarouselTests()
        {
            var tests = await _testRepository.QueryAsQueryable(a => true).OrderBy(a => a.ViewCount, SqlSugar.OrderByType.Desc).Take(4).ToListAsync();
            return tests.ConvertAll(a =>
            {
                return new VoTest()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    SmallImage = a.SmallImage,
                    ViewCount = a.ViewCount
                };
            });
        }

        /// <summary>
        /// 获取热门测试题
        /// </summary>
        /// <returns></returns>
        private async Task<List<VoTest>> GetHotTests()
        {
            var tests = await _testRepository.QueryAsQueryable(a => true).OrderBy(a => a.TestCount, SqlSugar.OrderByType.Desc).Take(6).ToListAsync();
            return tests.ConvertAll(a =>
            {
                return new VoTest()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    SmallImage = a.SmallImage,
                    ViewCount = a.ViewCount
                };
            });
        }

        /// <summary>
        /// 获取全部测试题
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task<PageModel<VoTest>> GetAllTests(InputOfIndexData input)
        {
            string sqlWhere = " 1 = 1";
            if (input.ClassifyId != (int)ClassifyIdEnum.全部测试)
            {
                sqlWhere += $" typeid = {input.ClassifyId}";
            }

            if (input.ScreenId != (int)ScreenIdEnum.全部)
            {
                sqlWhere += " testcount > 2000";
            }

            string orderField = null;
            switch (input.OrderId)
            {
                case (int)OrderIdEnum.全部:
                    break;

                case (int)OrderIdEnum.最新:
                    orderField = "createunixtime desc";
                    break;

                case (int)OrderIdEnum.最热:
                    orderField = "likecount desc";
                    break;

                default:
                    break;
            }

            var pageModel = await _testRepository.QueryPageModel(sqlWhere, input.PageIndex, input.PageSize, orderField);
            var data = pageModel.Data.ConvertAll(a =>
            {
                return new VoTest()
                {
                    Id = a.Id,
                    Content = a.Content,
                    SmallImage = a.SmallImage,
                    Title = a.Title,
                    ViewCount = a.ViewCount
                };
            });

            return new PageModel<VoTest>()
            {
                Data = data,
                DataCount = pageModel.DataCount,
                PageCount = pageModel.PageCount,
                PageIndex = pageModel.PageIndex,
                PageSize = pageModel.PageSize
            };
        }
    }
}