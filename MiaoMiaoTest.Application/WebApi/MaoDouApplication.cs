using MiaoMiaoTest.Config;
using MiaoMiaoTest.Models.Input.MaoDou;
using MiaoMiaoTest.Models.Utility;
using MiaoMiaoTest.Models.Vo.MaoDouController;
using MiaoMiaoTest.Services.WebApi;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Application.WebApi
{
    public class MaoDouApplication : IMaoDouApplication
    {
        private readonly IMaoDouService _maoDouService;

        public MaoDouApplication(IMaoDouService maoDouService)
        {
            _maoDouService = maoDouService;
        }

        public async Task<ApiResult<VoIndexData>> GetIndexDataAsync(InputOfIndexData input)
        {
            var data = await _maoDouService.GetIndexDataAsync(input);
            return new ApiResult<VoIndexData>
            {
                Code = (int)ApiResultCode.Success,
                Data = data,
                Message = "获取成功"
            };
        }
    }
}