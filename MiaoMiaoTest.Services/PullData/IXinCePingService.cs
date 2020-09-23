using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Services.PullData
{
    public interface IXinCePingService
    {
        Task<string> PullCharacterData(int pageStartIndex, int pageEndIndex);
        Task<string> PullLoveData(int pageStartIndex, int pageEndIndex);
        Task<string> PullTasteData(int pageStartIndex, int pageEndIndex);
    }
}
