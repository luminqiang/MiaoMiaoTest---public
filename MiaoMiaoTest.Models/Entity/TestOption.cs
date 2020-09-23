using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Models.Entity
{
    /// <summary>
    /// 测试选项
    /// </summary>
    [SugarTable("test_option")]
    public class TestOption
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 测试ID
        /// </summary>
        public long TestId { get; set; }

        /// <summary>
        /// 测试题目Id
        /// </summary>
        public long TestTitleId { get; set; }

        /// <summary>
        /// 测试选项
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// 标识ID，用于查找对应的答案
        /// </summary>
        public int FlagId { get; set; }
    }
}
