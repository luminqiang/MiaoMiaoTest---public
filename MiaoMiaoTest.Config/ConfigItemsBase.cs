using MiaoMiaoTest.Common.Extensions;
using MiaoMiaoTest.FrameWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Config
{
    public class ConfigItemsBase
    {
        protected const string TrueString = "1";

        protected const string FalseString = "0";

        protected const string ZeroString = "0";

        protected const int ZeroInt = 0;

        protected static string GetConnStringValue(string connKey, bool isThrow = true)
        {
            return GetConnStringValue(connKey, "", isThrow);
        }

        protected static string GetConnStringValue(string connKey, string defaultValue, bool isThrow = true)
        {
            string text = AppSettingsReader.GetString(connKey);
            if (string.IsNullOrEmpty(text))
            {
                if (isThrow)
                {
                    if (!string.IsNullOrEmpty(defaultValue))
                    {
                        return defaultValue;
                    }

                    throw new ArgumentException("未能找到 【" + connKey + "】节点的相关配置");
                }

                text = defaultValue;
            }

            return text;
        }

        protected static string GetConfigValue(string configKey, bool isThrow = true)
        {
            return GetConfigValue(configKey, "", isThrow);
        }

        protected static int GetConfigValue(string configKey, int defaultValue = 0, bool isThrow = true)
        {
            return GetConfigValue(configKey, defaultValue.ToString(), isThrow).ToInt();
        }

        protected static bool GetConfigValue(string configKey, bool defaultValue = false, bool isThrow = true)
        {
            return GetConfigValue(configKey, defaultValue ? "1" : "0", isThrow) == "1";
        }

        protected static string GetConfigValue(string configKey, string defaultValue, bool isThrow = true)
        {
            try
            {
                string appSettingString = AppSettingsReader.GetString(configKey);
                if (string.IsNullOrEmpty(appSettingString))
                {
                    if (isThrow)
                    {
                        if (string.IsNullOrEmpty(defaultValue))
                        {
                            throw new ArgumentException("未能找到 【" + configKey + "】节点的相关配置");
                        }

                        return defaultValue;
                    }

                    return defaultValue;
                }

                return appSettingString;
            }
            catch (Exception innerException)
            {
                if (isThrow)
                {
                    if (string.IsNullOrEmpty(defaultValue))
                    {
                        throw new ArgumentException("未能找到 【" + configKey + "】节点的相关配置", innerException);
                    }

                    return defaultValue;
                }

                return defaultValue;
            }
        }
    }
}
