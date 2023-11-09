using FluentValidation;
using Gunetberg.Domain.Tag;
namespace Gunetberg.Application.Validators
{
    public class CreateTagRequestValidator: AbstractValidator<CreateTagRequest>
    {
        public CreateTagRequestValidator()
        {
                RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
