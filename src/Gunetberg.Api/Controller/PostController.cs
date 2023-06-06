using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly PostApiConverter _postApiConverter;

        public PostController(IPostService postService, PostApiConverter postApiConverter)
        {
            _postService = postService;
            _postApiConverter = postApiConverter;
        }

        [HttpPost]
        public Guid CreatePost(CreatePostApiRequest createPostApiRequest)
        {
            return _postService.CreatePost(_postApiConverter.transform(createPostApiRequest));
        }
    }
}
