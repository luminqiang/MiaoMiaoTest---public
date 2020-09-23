using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Models.Utility;
using System.Collections.Generic;

namespace MiaoMiaoTest.Models.Vo.MaoDouController
{
    public class VoIndexData
    {
        /// <summary>
        /// 轮播图
        /// </summary>
        public List<VoTest> CarouselTests { get; set; }

        /// <summary>
        /// 热门测试
        /// </summary>
        public List<VoTest> HotTests { get; set; }

        /// <summary>
        /// 全部测试
        /// </summary>
        public PageModel<VoTest> AllTests { get; set; }
    }

    public class VoTest
    {
        /// <summary>
        /// 测试ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string SmallImage { get; set; }

        /// <summary>
        /// 测试标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 查看人数
        /// </summary>
        public int ViewCount { get; set; }
    }
}