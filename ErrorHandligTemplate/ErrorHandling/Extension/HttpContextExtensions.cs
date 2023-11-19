namespace ErrorHandligTemplate.ErrorHandling.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetRemoteIpAddress(this HttpContext context)
        {
            return context?.Connection?.RemoteIpAddress?.ToString();
        }
    }
}