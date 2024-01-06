using FluentValidation;
using Gunetberg.Application;

namespace Gunetberg.Host.Middleware.Handlers
{
    public class ValidationExceptionHandler: ExceptionHandler
    {
        public IEnumerable<ErrorBody> GetExceptionErrors(Exception exception)
        {
            var convertedException = exception as ValidationException;
            return convertedException.Errors.Select(x => GetErrorCodeFromValidation( x.ErrorCode));
        }

        private ErrorBody GetErrorCodeFromValidation(string errorCode)
        {
            var parsedError = Enum.Parse<ErrorCode>(errorCode);
            return new ErrorBody
            {
                ErrorCode = parsedError,
                ErrorName = parsedError.ToString(),
            };
        }
    }
}
