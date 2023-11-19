using System.Net;
using System.Security.Authentication;
using ErrorHandligTemplate.ErrorHandling.Exceptions;
using ErrorHandligTemplate.ErrorHandling.Extensions;

namespace ErrorHandligTemplate.ErrorHandling.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        public HandledResponse HandleError(Exception exception, string remoteIpAddress)
        {
            var exceptionType = exception.GetType();

            HandledResponse response;
            switch (exception)
            {
                case NotFoundException e when exceptionType == typeof(NotFoundException):
                    response = HandleNotFoundException(e);

                    break;

                case ForbiddenException e when exceptionType == typeof(ForbiddenException):
                    response = HandleForbiddenException(e);

                    break;

                case BusinessException e when exceptionType == typeof(BusinessException):
                    response = HandleBusinessException(e);

                    break;

                case AuthenticationException e when exceptionType == typeof(AuthenticationException):
                    response = HandleAuthenticationException(e);

                    break;

                case UnauthorizedAccessException e when exceptionType == typeof(UnauthorizedAccessException):
                    response = HandleUnauthorizedAccessException(e);

                    break;
                default:
                    response = HandleException(exception);
                    break;
            }

            HandleResponse(response, exception, remoteIpAddress);

            return response;
        }

        private void HandleResponse(HandledResponse response, Exception exception, string remoteIpAddress)
        {
            // Log your error here
        }

        private HandledResponse HandleNotFoundException(NotFoundException exception)
        {
            var httpResponseCode = HttpStatusCode.NotFound;

            var result = PrepareHandledResponse(
                httpResponseCode,
                exception.Code,
                exception.Message);

            return result;
        }

        private static HandledResponse PrepareHandledResponse(
            HttpStatusCode httpResponseCode,
            string code,
            string message)
        {
            return new HandledResponse()
            {
                HttpStatusCode = httpResponseCode,
                ErrorResponse = new ErrorResponse
                {
                    ExceptionId = Guid.NewGuid(),
                    Code = code,
                    Message = message
                }
            };
        }

        private HandledResponse HandleForbiddenException(ForbiddenException exception)
        {
            var httpResponseCode = HttpStatusCode.Forbidden;

            var result = PrepareHandledResponse(
                httpResponseCode,
                exception.Code,
                exception.Message);

            return result;
        }

        private HandledResponse HandleBusinessException(BusinessException exception)
        {
            var httpResponseCode = HttpStatusCode.BadRequest;

            var result = PrepareHandledResponse(
                httpResponseCode,
                exception.Code,
                exception.Message);

            return result;
        }

        private HandledResponse HandleForbiddenResponse(Exception exception)
        {
            var result = PrepareHandledResponse(
                HttpStatusCode.Forbidden,
                ExceptionExtensions.UnauthorizedReturnedCode,
                ExceptionExtensions.UnauthorizedReturnedMessage);

            return result;
        }

        private HandledResponse HandleAuthenticationException(AuthenticationException exception)
        {
            var httpResponseCode = HttpStatusCode.Unauthorized;

            var result = PrepareHandledResponse(
                httpResponseCode,
                ExceptionExtensions.UnauthenticatedReturnedCode,
                ExceptionExtensions.UnauthenticatedReturnedMessage);

            return result;
        }

        private HandledResponse HandleUnauthorizedAccessException(UnauthorizedAccessException exception)
        {
            return HandleForbiddenResponse(exception);
        }

        private HandledResponse HandleException(Exception exception)
        {
            var httpResponseCode = HttpStatusCode.InternalServerError;

            var result = PrepareHandledResponse(
                httpResponseCode,
                ExceptionExtensions.ExceptionReturnedCode,
                ExceptionExtensions.ExceptionReturnedMessage);

            return result;
        }
    }
}