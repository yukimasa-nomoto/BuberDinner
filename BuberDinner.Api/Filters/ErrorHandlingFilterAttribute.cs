using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;


            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred while processing your request2",
                Instance = context.HttpContext.Request.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            };


            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;

            //if(context.Exception is null)
            //{
            //    return;
            //}

            //base.OnException(context);
        }
    }
}
