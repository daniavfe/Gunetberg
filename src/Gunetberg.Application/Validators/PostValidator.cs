using FluentValidation;
using Gunetberg.Domain.Post;

namespace Gunetberg.Application.Validators;

public class PostValidator : AbstractValidator<CompletePost>
{
    public PostValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
