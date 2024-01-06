using Gunetberg.Application;

namespace Gunetberg.Host.Middleware
{
    public class ErrorBody
    {
        public ErrorCode ErrorCode { get; set; }
        public string ErrorName { get; set; }
    }
}
