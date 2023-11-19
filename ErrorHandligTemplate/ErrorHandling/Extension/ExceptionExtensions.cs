namespace ErrorHandligTemplate.ErrorHandling.Extensions
{
    public static class ExceptionExtensions
    {
        public static string ExceptionReturnedCode => "fatal_error";
        public static string ExceptionReturnedMessage => "Fatal error occured. Please contact with support.";
        public static string UnauthorizedReturnedCode => "unauthorized";
        public static string UnauthorizedReturnedMessage => "User unauthorized.";
        public static string UnauthenticatedReturnedCode => "unauthenticated";
        public static string UnauthenticatedReturnedMessage => "User unauthenticated.";
    }
}