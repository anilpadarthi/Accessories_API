﻿using System.Net;

namespace POS_Accessories.Models.Response
{
    public class CommonResponse
    {
        public bool status { get; set; }
        public int responseCode { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public int count { get; set; }

        public CommonResponse HandleException(Exception exception)
        {
            var response = new CommonResponse();
            var errorMessage = "error found: " + exception?.Message + "<br/>" + exception?.StackTrace;
            response.status = false;
            response.message = errorMessage;
            response.statusCode = HttpStatusCode.InternalServerError;
            return response;
        }
    }
}
