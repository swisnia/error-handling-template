namespace ErrorHandligTemplate.ErrorHandling.Exceptions
{
    public class ConfigurationException : BusinessException
    {
        public ConfigurationException(string code)
            : base(code)
        {
        }
        
        public ConfigurationException(string code, string message)
            : base(code, message)
        {
        }
    }
}