using Gunetberg.Api.Dto;
using Gunetberg.Domain.Post;

namespace Gunetberg.Api.Converter
{
    public class PostApiConverter
    {
        public CreatePostRequest transform(CreatePostApiRequest createPostApiRequest)
        {
            return new CreatePostRequest();
        }
    }
}
