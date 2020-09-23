using System.Security.Cryptography;
using System.Text;

namespace MiaoMiaoTest.Common
{
    public class Md5Helper
    {
        private static readonly MD5 md5 = MD5.Create();

        /// <summary>
        /// 使用utf8编码将字符串散列
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string GetMD5HashString(string sourceStr)
        {
            return GetMD5HashString(Encoding.UTF8, sourceStr);
        }

        /// <summary>
        /// 使用指定编码将字符串散列
        /// </summary>
        /// <param name="encode"></param>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string GetMD5HashString(Encoding encode, string sourceStr)
        {
            StringBuilder sb = new StringBuilder();

            byte[] source = md5.ComputeHash(encode.GetBytes(sourceStr));
            for (int i = 0; i < source.Length; i++)
            {
                sb.Append(source[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}