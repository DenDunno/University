using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using DbmsEmulator.Exceptions;

public class HttpResponseExceptionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpException exception)
        {
            context.Result = new JsonResult(exception.Message)
            {
                StatusCode = (int)exception.Response.StatusCode,
            };

            context.ExceptionHandled = true;
        }
    }
}