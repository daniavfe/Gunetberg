using FluentValidation;
using Gunetberg.Domain.Post;

namespace Gunetberg.Application.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        const int LanguageMaximumLengh = 10;
        const int TitleMaximumLengh = 150;
        const int SummaryMaximumLengh = 150;
        const int ContentMaximumLengh = 4000;
        const int ImageUrlMaximumLengh = 4000;

        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Language).NotEmpty().MaximumLength(LanguageMaximumLengh);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(TitleMaximumLengh);
            RuleFor(x => x.Summary).NotEmpty().MaximumLength(SummaryMaximumLengh);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(ContentMaximumLengh);
            RuleFor(x => x.ImageUrl).MaximumLength(ImageUrlMaximumLengh);
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
