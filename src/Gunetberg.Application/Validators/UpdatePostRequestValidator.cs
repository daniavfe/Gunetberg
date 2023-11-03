using FluentValidation;
using Gunetberg.Domain.Post;


namespace Gunetberg.Application.Validators
{
    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
