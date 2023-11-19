using System.Net;

namespace ErrorHandligTemplate.ErrorHandling.Exceptions
{
    public class HandledResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ErrorResponse ErrorResponse { get; set; }
    }
}