using FluentValidation;
using Gunetberg.Domain.Authorization;

namespace Gunetberg.Application.Authorization.Validator
{
    public class AuthorizationRequestValidator : AbstractValidator<AuthorizationRequest>
    {
        public AuthorizationRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
