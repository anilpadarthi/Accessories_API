using System.Net;

namespace POS_Accessories.Models.Response
{
    public class CommonResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public object data { get; set; }
        public bool status { get; set; }

        public CommonResponse HandleException(Exception exception)
        {
            var response = new CommonResponse();
            var errorMessage = "error found: " + exception?.Message + "<br/>" + exception?.StackTrace;
            response.data = errorMessage;
            response.statusCode = HttpStatusCode.InternalServerError;
            return response;
        }
    }
}
