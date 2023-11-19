namespace ErrorHandligTemplate.ErrorHandling.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string code)
            : base(code)
        {
        }
        
        public NotFoundException(string code, string message)
            : base(code, message)
        {
        }
    }
}