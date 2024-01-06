using FluentValidation;
using Gunetberg.Domain.Exception;
using Gunetberg.Host.Middleware.Handlers;
using System.Net;

namespace Gunetberg.Host.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var exceptionHandler = GetExceptionHandler(exception);
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                await response.WriteAsJsonAsync(exceptionHandler.GetExceptionErrors(exception));
            }
        }

        private ExceptionHandler GetExceptionHandler(Exception exception)
        {
            switch (exception)
            {
                case ValidationException:
                    return new ValidationExceptionHandler();
                case EmailAlreadyInUseException:
                    return new EmailAlreadyInUseExceptionHandler();
                case AliasAlreadyInUseException:
                    return new AliasAlreadyInUseExceptionhandler();
                default:
                    return new DefaultExceptionHandler();
            }
        }
    }
}
