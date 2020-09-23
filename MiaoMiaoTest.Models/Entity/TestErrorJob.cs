using SqlSugar;
using System;

namespace MiaoMiaoTest.Models.Entity
{
    /// <summary>
    /// 异常作业信息表
    /// </summary>
    [SugarTable("test_errorjob")]
    public class TestErrorJob
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 采集地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 对方ID
        /// </summary>
        public long OtherId { get; set; }

        /// <summary>
        /// 来源ID
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// 异常堆栈信息
        /// </summary>
        public string ExceptionStackInfo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreateUnixTime { get; set; }
    }
}