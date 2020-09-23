using MiaoMiaoTest.Config;
using MiaoMiaoTest.Models.Utility;
using MiaoMiaoTest.Services.PullData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Application.PullData
{
    public class XinPingCeApplication : IXinPingCeApplication
    {
        public IXinCePingService _xinCePingService;
        public XinPingCeApplication(IXinCePingService xinCePingService)
        {
            _xinCePingService = xinCePingService;
        }

        public async Task<ApiResult<string>> PullCharacterData(int pageStartIndex, int pageEndIndex)
        {
            var data = await _xinCePingService.PullCharacterData(pageStartIndex, pageEndIndex);
            return new ApiResult<string>
            {
                Code = (int)ApiResultCode.Success,
                Data = null,
                Message = data
            };
        }

        public async Task<ApiResult<string>> PullLoveData(int pageStartIndex, int pageEndIndex)
        {
            var data = await _xinCePingService.PullLoveData(pageStartIndex, pageEndIndex);
            return new ApiResult<string>
            {
                Code = (int)ApiResultCode.Success,
                Data = null,
                Message = data
            };
        }

        public async Task<ApiResult<string>> PullTasteData(int pageStartIndex, int pageEndIndex)
        {
            var data = await _xinCePingService.PullTasteData(pageStartIndex, pageEndIndex);
            return new ApiResult<string>
            {
                Code = (int)ApiResultCode.Success,
                Data = null,
                Message = data
            };
        }
    }
}
