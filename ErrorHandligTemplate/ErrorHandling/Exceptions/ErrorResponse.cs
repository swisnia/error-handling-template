namespace ErrorHandligTemplate.ErrorHandling.Exceptions
{
    public class ErrorResponse
    {
        public Guid ExceptionId { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}