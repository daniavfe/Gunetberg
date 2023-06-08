using FluentValidation;
using Gunetberg.Domain.Post;
using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Application.Post.Validator
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        const int LanguageMaximumLengh = 3;
        const int TitleMaximumLengh = 200;

        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Language).NotNull().MaximumLength(LanguageMaximumLengh);
            RuleFor(x => x.Title).NotNull().MaximumLength(TitleMaximumLengh);
            RuleFor(x => x.CreatedAt).NotNull();
            RuleFor(x => x.CreatedBy).NotNull();

        }
    }
}
