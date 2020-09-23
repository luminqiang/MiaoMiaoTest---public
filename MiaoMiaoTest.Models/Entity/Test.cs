using SqlSugar;
using System;
using System.Collections.Generic;

namespace MiaoMiaoTest.Models.Entity
{
    /// <summary>
    /// 测试表
    /// </summary>
    [SugarTable("test")]
    public class Test
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 来源ID
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// 对方ID
        /// </summary>
        public long OtherId { get; set; }

        /// <summary>
        /// 测试标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string LabelName { get; set; }

        /// <summary>
        /// 小配图
        /// </summary>
        public string SmallImage { get; set; }

        /// <summary>
        /// 大配图
        /// </summary>
        public string BigImage { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 发布时间戳
        /// </summary>
        public long UnixTime { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 测试数量
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 测试数量
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 测试人数
        /// </summary>
        public int TestCount { get; set; }

        /// <summary>
        /// 真实收藏数量
        /// </summary>
        public int RealLikeCount { get; set; }

        /// <summary>
        /// 真实浏览数量
        /// </summary>
        public int RealViewCount { get; set; }

        /// <summary>
        /// 真实测试人数
        /// </summary>
        public int RealTestCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreateUnixTime { get; set; }

        /// <summary>
        /// 测试题目
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<TestTitle> TestTitles { get; set; }       

        /// <summary>
        /// 测试标签
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<TestLabel> TestLabels { get; set; }
    }
}