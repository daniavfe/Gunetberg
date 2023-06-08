using FluentValidation;
using Gunetberg.Domain.Post;

namespace Gunetberg.Application.Post.Validator;

public class PostValidator : AbstractValidator<CompletePost>
{
    public PostValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
