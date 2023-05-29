using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieManagement.Filters
{
    public class GlobalAuthorizationFilter : IAuthorizationFilter
    {

        public GlobalAuthorizationFilter()
        {

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //context.Result = new JsonResult(new { message = "Unauthorized" })
            //{ StatusCode = StatusCodes.Status401Unauthorized };
           
        }
    }
}
