using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Client.Identity;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IdentityUtil _identityUtil;
        

        public PostController(IPostService postService, IdentityUtil identityUtil)
        {
            _postService = postService;
            _identityUtil = identityUtil;
            _postApiConverter = new PostApiConverter();
        }

        [HttpPost]
        [Route("/posts")]
        public Task<Guid> CreatePost(CreatePostRequestDto createPostApiRequest)
        {
            return _postService.CreatePost(
                _postApiConverter.ToCreatePostRequest(createPostApiRequest, _identityUtil.GetUserId())
                );
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/posts/search")]
        public async Task<SearchResultDto<SummaryPostDto>> SearchPosts(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            return _postApiConverter.ToSearchPostResultDto(
                await _postService.SearchPosts(_postApiConverter.ToSearchPostRequest(searchPostRequestDto)));
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("/posts/{id}")]
        public async Task<CompletePostDto> GetPost(Guid id)
        {
            return _postApiConverter.ToPostDto(await _postService.GetPost(id));
        }
    }
}
