using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly PostApiConverter _postApiConverter;

        public PostController(IPostService postService)
        {
            _postService = postService;
            _postApiConverter = new PostApiConverter();
        }

        [HttpPost]
        [Route("/posts")]
        public Guid CreatePost(CreatePostRequestDto createPostApiRequest)
        {
            return _postService.CreatePost(_postApiConverter.ToCreatePostRequest(createPostApiRequest));
        }

        [HttpPost]
        [Route("/posts/search")]
        public SearchPostResultDto SearchPosts(SearchPostRequestDto searchPostRequestDto)
        {
            return _postApiConverter.ToSearchPostResultDto(
                _postService.SearchPosts(_postApiConverter.ToSearchPostRequest(searchPostRequestDto))
                );
        }

        [HttpGet]
        [Route("/posts")]
        public IEnumerable<SummaryPostDto> GetPosts()
        {
            return _postApiConverter.ToSummaryPostDto(_postService.GetPosts());
        }

        [HttpGet]
        [Route("/posts/{id}")]
        public PostDto GetPost(Guid id)
        {
            return _postApiConverter.ToPostDto(_postService.GetPost(id));
        }
    }
}
