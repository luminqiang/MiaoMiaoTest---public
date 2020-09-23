namespace MiaoMiaoTest.Models.Input.MaoDou
{
    public class InputOfIndexData : InputOfPageBase
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public int ClassifyId { get; set; } = 0;

        /// <summary>
        /// 排序ID
        /// </summary>
        public int OrderId { get; set; } = 0;

        /// <summary>
        /// 筛选ID
        /// </summary>
        public int ScreenId { get; set; } = 0;
    }
}