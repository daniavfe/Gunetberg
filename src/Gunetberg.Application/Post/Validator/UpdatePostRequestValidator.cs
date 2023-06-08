using FluentValidation;
using Gunetberg.Domain.Post;


namespace Gunetberg.Application.Post.Validator
{
    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
