using System;
using System.Net;

namespace SistemaCompra.CrossCutting.Utils

{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; private set; }
        public T Response { get; private set; }
        public string Message { get; private set; }
        public bool Success { get; private set; }

        public ApiResponse() { }

        public ApiResponse<T> Ok(T response)
        {
            StatusCode = HttpStatusCode.OK;
            Response = response;
            Success = true;

            return this;
        }

        public ApiResponse<T> Error(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Success = false;

            return this;
        }

    }
}
