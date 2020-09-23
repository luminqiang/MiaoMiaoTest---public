namespace MiaoMiaoTest.FrameWork
{
    public static class IocManager
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>(string name = null)
        {
            return (T)FrameWorkUtil.Instance.ServiceProvider.GetService(typeof(T));
        }
    }
}