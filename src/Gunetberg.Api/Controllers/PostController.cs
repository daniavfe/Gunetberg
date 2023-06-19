using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Common;
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
        public Task<Guid> CreatePost(CreatePostRequestDto createPostApiRequest)
        {
            return _postService.CreatePost(_postApiConverter.ToCreatePostRequest(createPostApiRequest));
        }

        [HttpPost]
        [Route("/posts/search")]
        public async Task<SearchResultDto<SummaryPostDto>> SearchPosts(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            return _postApiConverter.ToSearchPostResultDto(
                await _postService.SearchPosts(_postApiConverter.ToSearchPostRequest(searchPostRequestDto)));
        }


        [HttpGet]
        [Route("/posts/{id}")]
        public async Task<PostDto> GetPost(Guid id)
        {
            return _postApiConverter.ToPostDto(await _postService.GetPost(id));
        }
    }
}
