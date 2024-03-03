using Gunetberg.Application.Errors;

namespace Gunetberg.Host.Middleware.Handlers
{
    public class DefaultExceptionHandler : ExceptionHandler
    {
        public IEnumerable<ErrorBody> GetExceptionErrors(Exception exception)
        {
            return new ErrorBody[] { new ErrorBody { ErrorCode= ErrorCode.Unknown, ErrorName = ErrorCode.Unknown.ToString() } };
        }
    }
}
