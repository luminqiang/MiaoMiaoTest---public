using MiaoMiaoTest.Application.PullData;
using MiaoMiaoTest.Models.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MiaoMiaoTest.WebApi.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IXinPingCeApplication _xinPingCeApplication;

        public JobController(IXinPingCeApplication xinPingCeApplication)
        {
            _xinPingCeApplication = xinPingCeApplication;
        }

        [HttpGet("xinpingce/character")]
        public async Task<ApiResult<string>> PullCharacterData([FromQuery]int pageStartIndex = 1, [FromQuery] int pageEndIndex = 1)
        {
            return await _xinPingCeApplication.PullCharacterData(pageStartIndex, pageEndIndex);
        }

        [HttpGet("xinpingce/taste")]
        public async Task<ApiResult<string>> PullTasteData([FromQuery] int pageStartIndex = 1, [FromQuery] int pageEndIndex = 1)
        {
            return await _xinPingCeApplication.PullTasteData(pageStartIndex, pageEndIndex);
        }

        [HttpGet("xinpingce/love")]
        public async Task<ApiResult<string>> PullLoveData([FromQuery] int pageStartIndex = 1, [FromQuery] int pageEndIndex = 1)
        {
            return await _xinPingCeApplication.PullLoveData(pageStartIndex, pageEndIndex);
        }
    }
}