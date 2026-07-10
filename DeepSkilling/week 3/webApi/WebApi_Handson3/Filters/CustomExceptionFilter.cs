using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            File.AppendAllText(
                "ErrorLog.txt",
                context.Exception.ToString());

            context.Result = new ObjectResult(
                "Internal Server Error")
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}