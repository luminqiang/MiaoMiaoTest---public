using SqlSugar;

namespace MiaoMiaoTest.Models.Entity
{
    /// <summary>
    /// 测试标签
    /// </summary>
    [SugarTable("test_label")]
    public class TestLabel
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
        /// 标签
        /// </summary>
        public string Label { get; set; }
    }
}