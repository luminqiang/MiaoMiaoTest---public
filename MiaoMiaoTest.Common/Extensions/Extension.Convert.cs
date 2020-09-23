﻿using MiaoMiaoTest.Common.Helpers;
using System;

namespace MiaoMiaoTest.Common.Extensions
{
    /// <summary>
    /// 系统扩展 - 类型转换
    /// </summary>
    public static partial class Extension
    {
        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="input">输入值</param>
        public static string SafeString(this object input)
        {
            return input?.ToString().Trim() ?? string.Empty;
        }

        /// <summary>
        /// 转换为bool
        /// </summary>
        /// <param name="obj">数据</param>
        public static bool ToBool(this string obj)
        {
            return ConvertHelper.ToBool(obj);
        }

        /// <summary>
        /// 转换为可空bool
        /// </summary>
        /// <param name="obj">数据</param>
        public static bool? ToBoolOrNull(this string obj)
        {
            return ConvertHelper.ToBoolOrNull(obj);
        }

        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="obj">数据</param>
        public static int ToInt(this string obj)
        {
            return ConvertHelper.ToInt(obj);
        }

        /// <summary>
        /// 转换为可空int
        /// </summary>
        /// <param name="obj">数据</param>
        public static int? ToIntOrNull(this string obj)
        {
            return ConvertHelper.ToIntOrNull(obj);
        }

        /// <summary>
        /// 转换为long
        /// </summary>
        /// <param name="obj">数据</param>
        public static long ToLong(this string obj)
        {
            return ConvertHelper.ToLong(obj);
        }

        /// <summary>
        /// 转换为可空long
        /// </summary>
        /// <param name="obj">数据</param>
        public static long? ToLongOrNull(this string obj)
        {
            return ConvertHelper.ToLongOrNull(obj);
        }

        /// <summary>
        /// 转换为double
        /// </summary>
        /// <param name="obj">数据</param>
        public static double ToDouble(this string obj)
        {
            return ConvertHelper.ToDouble(obj);
        }

        /// <summary>
        /// 转换为可空double
        /// </summary>
        /// <param name="obj">数据</param>
        public static double? ToDoubleOrNull(this string obj)
        {
            return ConvertHelper.ToDoubleOrNull(obj);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <param name="obj">数据</param>
        public static decimal ToDecimal(this string obj)
        {
            return ConvertHelper.ToDecimal(obj);
        }

        /// <summary>
        /// 转换为可空decimal
        /// </summary>
        /// <param name="obj">数据</param>
        public static decimal? ToDecimalOrNull(this string obj)
        {
            return ConvertHelper.ToDecimalOrNull(obj);
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj">数据</param>
        public static DateTime ToDate(this string obj)
        {
            return ConvertHelper.ToDate(obj);
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="obj">数据</param>
        public static DateTime? ToDateOrNull(this string obj)
        {
            return ConvertHelper.ToDateOrNull(obj);
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="obj">数据</param>
        public static Guid ToGuid(this string obj)
        {
            return ConvertHelper.ToGuid(obj);
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="obj">数据</param>
        public static Guid? ToGuidOrNull(this string obj)
        {
            return ConvertHelper.ToGuidOrNull(obj);
        }
    }
}