using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Client.Identity;
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
        private readonly IdentityUtil _identityUtil;
        

        public PostController(IPostService postService, IdentityUtil identityUtil, PostApiConverter postApiConverter)
        {
            _postService = postService;
            _identityUtil = identityUtil;
            _postApiConverter = postApiConverter;
        }

        [HttpDelete]
        [Route("/posts/{id}")]
        public async Task DeletePost(Guid id)
        {
            await _postService.DeletePost(id);
        }


        [HttpPost]
        [Route("/posts")]
        public async Task<Guid> CreatePost(CreatePostRequestDto createPostApiRequest)
        {
            return await _postService.CreatePost(
                _postApiConverter.ToCreatePostRequest(createPostApiRequest, _identityUtil.GetUserId())
            );
        }

        [HttpPut]
        [Route("/posts/{id}")]
        public async Task UpdatePost(Guid id, UpdatePostRequestDto updatePostApiRequest)
        {
            await _postService.UpdatePost(
                _postApiConverter.ToUpdatePostRequest(id, _identityUtil.GetUserId(), updatePostApiRequest)
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


        [HttpPost]
        [AllowAnonymous]
        [Route("/posts/admin/search")]
        public async Task<SearchResultDto<AdminPostDto>> SearchAdminPosts(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            return _postApiConverter.ToSearchPostResultDto(
                await _postService.SearchAdminPosts(_postApiConverter.ToSearchPostRequest(searchPostRequestDto)));
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("/posts/{id}")]
        public async Task<CompletePostDto> GetPost(Guid id)
        {
            return _postApiConverter.ToPostDto(await _postService.GetPost(id));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/posts")]
        public async Task<CompletePostDto> GetPost([FromQuery] string title)
        {
            return _postApiConverter.ToPostDto(await _postService.GetPost(_postApiConverter.toTitle(title)));
        }
    }
}
