using Gunetberg.Application;

namespace Gunetberg.Host.Middleware.Handlers
{
    public abstract class EntityNotFoundExceptionHandler : ExceptionHandler
    {
        public IEnumerable<ErrorBody> GetExceptionErrors(Exception exception)
        {
            return new ErrorBody[] { GetExceptionFromType() };
        }

        protected abstract ErrorBody GetExceptionFromType();
    }
}
