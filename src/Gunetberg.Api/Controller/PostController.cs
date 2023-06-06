using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Post;
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
        public Guid CreatePost(CreatePostRequestDto createPostApiRequest)
        {
            return _postService.CreatePost(_postApiConverter.ToCreatePostRequest(createPostApiRequest));
        }

        [HttpPost]
        public SearchPostResultDto SearchPosts(SearchPostRequestDto searchPostRequestDto)
        {
            return _postApiConverter.ToSearchPostResultDto(
                _postService.SearchPost(_postApiConverter.ToSearchPostRequest(searchPostRequestDto))
                );
        }

        [HttpGet]
        public IEnumerable<SummaryPostDto> GetPosts()
        {
            return _postApiConverter.ToSummaryPostDto(_postService.GetPosts());
        }

        [HttpGet]
        public PostDto GetPost(Guid id)
        {
            return _postApiConverter.ToPostDto(_postService.GetPost(id));
        }
    }
}
