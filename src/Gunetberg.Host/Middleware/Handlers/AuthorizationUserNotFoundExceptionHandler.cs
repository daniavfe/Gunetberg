using Gunetberg.Application.Errors;

namespace Gunetberg.Host.Middleware.Handlers
{
    public class AuthorizationUserNotFoundExceptionHandler : EntityNotFoundExceptionHandler
    {
        protected override ErrorBody GetExceptionFromType()
        {
            return new ErrorBody
            {
                ErrorCode = ErrorCode.AuthorizationUserNotFound,
                ErrorName = ErrorCode.AuthorizationUserNotFound.ToString()
            };
        }
    }
}
