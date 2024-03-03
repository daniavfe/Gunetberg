using Gunetberg.Application.Errors;

namespace Gunetberg.Host.Middleware.Handlers
{
    public class AliasAlreadyInUseExceptionhandler : ExceptionHandler
    {
        public IEnumerable<ErrorBody> GetExceptionErrors(Exception exception)
        {
            return new ErrorBody[] { new ErrorBody { ErrorCode = ErrorCode.AliasAlreadyInUse, ErrorName = ErrorCode.AliasAlreadyInUse.ToString() } };
        }
    }
}
