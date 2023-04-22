using Microsoft.AspNetCore.Mvc.Filters;
using MovieManagement.Models;
using System.Runtime.CompilerServices;

namespace MovieManagement
{
    public static class ExceptionExtensions
    {
        private static readonly Dictionary<string, Func<ExceptionContext, int, string, ErrorModel>> exceptionMap =
            new Dictionary<string, Func<ExceptionContext, int, string, ErrorModel>>
            {
                {"ArgumentException",ArgumentExceptionHandler }
                ,{"NullReferenceException",NullReferenceExceptionHandler },
                {"TimeoutException",TimeoutExceptionHandler },
                {"SqlException",SqlExceptionHandler },
            };

        public static ErrorModel GetCustomErrorModel(ExceptionContext context,string requestId,string traceid, int moduleNo, string baseHelpURL)
        {
            ErrorModel obj = new ErrorModel { code = 500 };
            DefaultInterpolatedStringHandler ds = new DefaultInterpolatedStringHandler(1, 2);
            ds.AppendFormatted(moduleNo);
            ds.AppendLiteral("-");
            ds.AppendFormatted(1);
            obj.Error = ds.ToStringAndClear();
            obj.Message = "Internal server Error occured";
            obj.Details = context.Exception.Message;
            obj.RequestId = requestId;
            obj.traceId = traceid;
            obj.HelpUrl = baseHelpURL + "/ISE";
            ErrorModel result = obj;
            if (exceptionMap.TryGetValue(context.Exception.GetType().Name, out var value))
            {
                result=value(context, moduleNo, baseHelpURL);
            }
            return result;
        }
        private static ErrorModel SqlExceptionHandler(ExceptionContext context, int moduleNo, string baseHelpURL)
        {
            ErrorModel obj = new ErrorModel();
            DefaultInterpolatedStringHandler ds = new DefaultInterpolatedStringHandler(1, 2);
            ds.AppendFormatted(moduleNo);
            ds.AppendLiteral("-");
            ds.AppendFormatted(400);
            obj.Error = ds.ToStringAndClear();
            obj.Message = "SQL server Error occured";
            obj.Details = context.Exception.Message;
            obj.HelpUrl = baseHelpURL + "/BadRequestError";
            return obj;
        }
        private static ErrorModel TimeoutExceptionHandler(ExceptionContext context, int moduleNo, string baseHelpURL)
        {
            ErrorModel obj = new ErrorModel();
            DefaultInterpolatedStringHandler ds = new DefaultInterpolatedStringHandler(1, 2);
            ds.AppendFormatted(moduleNo);
            ds.AppendLiteral("-");
            ds.AppendFormatted(100);
            obj.Error = ds.ToStringAndClear();
            obj.Message = "Connection Timeout Error occured";
            obj.Details = context.Exception.Message;
            obj.HelpUrl = baseHelpURL + "/BadRequestError";
            return obj;
        }
        private static ErrorModel NullReferenceExceptionHandler(ExceptionContext context, int moduleNo, string baseHelpURL)
        {
            ErrorModel obj = new ErrorModel ();
            DefaultInterpolatedStringHandler ds = new DefaultInterpolatedStringHandler(1, 2);
            ds.AppendFormatted(moduleNo);
            ds.AppendLiteral("-");
            ds.AppendFormatted(300);
            obj.Error = ds.ToStringAndClear();
            obj.Message = "Null Reference  Error occured";
            obj.Details = context.Exception.Message;
            obj.HelpUrl = baseHelpURL + "/BadRequestError";
            return obj;
        }

        private static ErrorModel ArgumentExceptionHandler(ExceptionContext context, int moduleNo, string baseHelpURL)
        {
            ErrorModel obj = new ErrorModel { code = 400 };
            DefaultInterpolatedStringHandler ds = new DefaultInterpolatedStringHandler(1, 2);
            ds.AppendFormatted(moduleNo);
            ds.AppendLiteral("-");
            ds.AppendFormatted(500);
            obj.Error = ds.ToStringAndClear();
            obj.Message = "Invalid Argument Error occured";
            obj.Details = context.Exception.Message;
            obj.HelpUrl = baseHelpURL + "/BadRequestError";
            return obj;

        }
    }
}
