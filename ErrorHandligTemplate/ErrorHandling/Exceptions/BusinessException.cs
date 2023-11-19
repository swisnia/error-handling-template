namespace ErrorHandligTemplate.ErrorHandling.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; protected set; }

        public BusinessException(string code)
        {
            Code = code;
        }
        
        public BusinessException(string code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}