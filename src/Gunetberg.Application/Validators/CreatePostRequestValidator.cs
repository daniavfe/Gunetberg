using FluentValidation;
using Gunetberg.Domain.Post;

namespace Gunetberg.Application.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        const int LanguageMaximumLengh = 5;
        const int TitleMaximumLengh = 200;

        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Language).NotEmpty().MaximumLength(LanguageMaximumLengh);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(TitleMaximumLengh);
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
