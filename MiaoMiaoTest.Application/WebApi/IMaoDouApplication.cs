using MiaoMiaoTest.Models.Input.MaoDou;
using MiaoMiaoTest.Models.Utility;
using MiaoMiaoTest.Models.Vo.MaoDouController;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Application.WebApi
{
    public interface IMaoDouApplication
    {
        Task<ApiResult<VoIndexData>> GetIndexDataAsync(InputOfIndexData input);
    }
}
