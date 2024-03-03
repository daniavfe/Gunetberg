using FluentValidation;
using Gunetberg.Application.Errors;
using Gunetberg.Domain.Authorization;

namespace Gunetberg.Application.Validators
{
    public class AuthorizationRequestValidator : AbstractValidator<AuthorizationRequest>
    {
        public AuthorizationRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithErrorCode(ErrorCode.EmptyEmail.ToString());
            RuleFor(x => x.Email).EmailAddress().WithErrorCode(ErrorCode.IncorrectEmail.ToString());
            RuleFor(x => x.Password).NotEmpty().WithErrorCode(ErrorCode.EmptyPassword.ToString());
        }
    }
}
