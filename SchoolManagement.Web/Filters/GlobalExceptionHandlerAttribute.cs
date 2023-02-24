using SchoolManagement.Web.ApiModels;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

namespace SchoolManagement.Web.Filters
{
    public class GlobalExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Log.Error(context.Exception, "Unhandled exception occurred");

            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            var errorResponse = new ErrorResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "An unexpected error occurred. Please try again later."
            };
            context.Response.Content = new ObjectContent<ErrorResponse>(errorResponse, new JsonMediaTypeFormatter());
        }
    }
}