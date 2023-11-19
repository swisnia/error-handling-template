namespace ErrorHandligTemplate.ErrorHandling.Exceptions
{
    public class ForbiddenException : BusinessException
    {
        public ForbiddenException(string code)
            : base(code)
        {
        }        
        
        public ForbiddenException(string code, string message)
            : base(code, message)
        {
        }
    }
}