using FluentValidation;
using Gunetberg.Domain.User;

namespace Gunetberg.Application.User.Validator
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PasswordCheck).NotEmpty();
            RuleFor(x => x.PasswordCheck).Equal(x => x.Password);
        }
    }
}
