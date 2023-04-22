using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieManagement.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;
        private readonly IConfiguration configuration;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger, IConfiguration configuration)
        {
            this.env = env;
            this.logger = logger;
            this.configuration = configuration;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);
            var errorModel = ExceptionExtensions.GetCustomErrorModel(context, context.HttpContext.Request.Headers.RequestId
                , "TraceId-", 1, "baseurl");
            context.Result = new ContentResult
            {
                Content = Newtonsoft.Json.JsonConvert.SerializeObject(errorModel),
                ContentType = "text/json"
            };
            context.ExceptionHandled = true;
        }
    }
}
