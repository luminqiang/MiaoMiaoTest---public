using MiaoMiaoTest.Config;
using MiaoMiaoTest.Models.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MiaoMiaoTest.WebApi.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //var controller = context.RouteData.Values["controller"] as string;
            //var action = context.RouteData.Values["action"] as string;
            context.Result = new ApplicationErrorResult(new ApiResult<string>()
            {
                Code = (int)ApiResultCode.UnknownError,
                Data = context.Exception.Message,
                Message = "系统错误，请重试"
            });

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
        }
    }

    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}