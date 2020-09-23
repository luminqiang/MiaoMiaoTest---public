using System;
using System.ComponentModel;

namespace MiaoMiaoTest.Config
{
    public enum ApiResultCode
    {
        [Description("成功")]
        Success = 0,

        [Description("参数错误")]
        ParamError = -10001,

        [Description("未知错误")]
        UnknownError = -10002
    }
}
