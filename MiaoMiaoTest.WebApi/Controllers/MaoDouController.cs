using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiaoMiaoTest.Application.WebApi;
using MiaoMiaoTest.Models.Input.MaoDou;
using MiaoMiaoTest.Models.Utility;
using MiaoMiaoTest.Models.Vo.MaoDouController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiaoMiaoTest.WebApi.Controllers
{
    [Route("api/maodou")]
    [ApiController]
    public class MaoDouController : ControllerBase
    {
        private readonly IMaoDouApplication _maoDouApplication;

        public MaoDouController(IMaoDouApplication maoDouApplication)
        {
            _maoDouApplication = maoDouApplication;
        }

        [HttpGet("index")]
        public async Task<ApiResult<VoIndexData>> GetIndexDataAsync([FromQuery] InputOfIndexData input)
        {
            return await _maoDouApplication.GetIndexDataAsync(input);
        }
    }
}
