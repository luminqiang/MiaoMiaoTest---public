using MiaoMiaoTest.Models.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Application.PullData
{
    public interface IXinPingCeApplication
    {
        Task<ApiResult<string>> PullCharacterData(int pageStartIndex, int pageEndIndex);
        Task<ApiResult<string>> PullLoveData(int pageStartIndex, int pageEndIndex);
        Task<ApiResult<string>> PullTasteData(int pageStartIndex, int pageEndIndex);
    }
}
