using Gunetberg.Application;

namespace Gunetberg.Host.Middleware.Handlers
{
    public class EmailAlreadyInUseExceptionHandler : ExceptionHandler
    {
        public IEnumerable<ErrorBody> GetExceptionErrors(Exception exception)
        {
            return new ErrorBody[] { new ErrorBody {ErrorCode = ErrorCode.EmailAlreadyInUse, ErrorName = ErrorCode.EmailAlreadyInUse.ToString()} };
        }
    }
}
