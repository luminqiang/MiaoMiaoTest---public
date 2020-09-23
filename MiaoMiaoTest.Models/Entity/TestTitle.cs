using SqlSugar;
using System.Collections.Generic;

namespace MiaoMiaoTest.Models.Entity
{
    /// <summary>
    /// 测试题目
    /// </summary>
    [SugarTable("test_title")]
    public class TestTitle
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
        /// 测试标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 测试选项
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<TestOption> TestOptions { get; set; }

        /// <summary>
        /// 测试答案
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<TestAnswer> TestAnswers { get; set; }
    }
}