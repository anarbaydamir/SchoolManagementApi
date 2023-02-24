using System.Net;

namespace SchoolManagement.Web.ApiModels
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}