using ErrorHandligTemplate.ErrorHandling.Exceptions;

namespace ErrorHandligTemplate.ErrorHandling.Handlers
{
    public interface IExceptionHandler
    {
        HandledResponse HandleError(Exception exception, string remoteIpAddress);
    }
}