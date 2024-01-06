namespace Gunetberg.Host.Middleware.Handlers
{
    public interface ExceptionHandler
    {
        public IEnumerable<ErrorBody> GetExceptionErrors(Exception exception);
    }
}
