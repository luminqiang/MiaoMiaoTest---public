using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Config
{
    public class ConfigItems : ConfigItemsBase
    {
        /// <summary>
        /// string
        /// </summary>
        public static string AppName => GetConfigValue("AppName", "联运游戏悬浮球前台", false);

        /// <summary>
        /// int
        /// </summary>
        public static int LogInfoSwitch => GetConfigValue("LogInfoSwitch", 1, false);

        /// <summary>
        /// bool
        /// </summary>
        public static bool TimeWatcherIsOpen => GetConfigValue("TimeWatcherIsOpen", false, false);
    }
}
