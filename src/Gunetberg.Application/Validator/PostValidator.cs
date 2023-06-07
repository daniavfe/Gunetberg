using FluentValidation;
using Gunetberg.Domain.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunetberg.Application.Validator
{
    public class PostValidator: AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
