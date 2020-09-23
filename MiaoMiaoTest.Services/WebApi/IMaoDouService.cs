using MiaoMiaoTest.Models.Input.MaoDou;
using MiaoMiaoTest.Models.Vo.MaoDouController;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiaoMiaoTest.Services.WebApi
{
    public interface IMaoDouService
    {
        Task<VoIndexData> GetIndexDataAsync(InputOfIndexData input);
    }
}
