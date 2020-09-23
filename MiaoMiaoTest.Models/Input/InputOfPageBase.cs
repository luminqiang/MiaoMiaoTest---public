using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Models.Input
{
    /// <summary>
    /// 入参 - 分页参数基类
    /// </summary>
    public class InputOfPageBase
    {
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
