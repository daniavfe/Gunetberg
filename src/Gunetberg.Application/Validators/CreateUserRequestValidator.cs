using FluentValidation;
using Gunetberg.Domain.User;

namespace Gunetberg.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Alias).NotEmpty().WithErrorCode(ErrorCode.EmptyAlias.ToString());
            RuleFor(x => x.Email).NotEmpty().WithErrorCode(ErrorCode.EmptyEmail.ToString());
            RuleFor(x => x.Email).EmailAddress().WithErrorCode(ErrorCode.IncorrectEmail.ToString());
            RuleFor(x => x.Password).NotEmpty().WithErrorCode(ErrorCode.EmptyPassword.ToString());
            RuleFor(x => x.PasswordCheck).NotEmpty().WithErrorCode(ErrorCode.EmptyPasswordCheck.ToString());
            RuleFor(x => x.PasswordCheck).Equal(x => x.Password).WithErrorCode(ErrorCode.PasswordsMissmach.ToString());
        }
    }
}
