using FluentValidation;
using Gunetberg.Domain.Comment;

namespace Gunetberg.Application.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentRequest>
    {
        const int contentMaximumLengh = 250;
        public CreateCommentValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.Content).NotEmpty().MaximumLength(contentMaximumLengh);
        }
    }
}
