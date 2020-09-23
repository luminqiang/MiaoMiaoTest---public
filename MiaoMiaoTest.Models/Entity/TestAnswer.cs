using SqlSugar;

namespace MiaoMiaoTest.Models.Entity
{
    /// <summary>
    /// 测试答案
    /// </summary>
    [SugarTable("test_answer")]
    public class TestAnswer
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
        /// 测试选项Id
        /// </summary>
        public long TestOptionId { get; set; }

        /// <summary>
        /// 测试答案
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 标识ID，用于查找对应的答案
        /// </summary>
        public int FlagId { get; set; }
    }
}