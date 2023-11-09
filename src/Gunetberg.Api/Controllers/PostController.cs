using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Client.Identity;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        private readonly PostApiConverter _postApiConverter;
        private readonly IdentityUtil _identityUtil;

        public PostController(ILogger<PostController> logger, IPostService postService, IdentityUtil identityUtil, PostApiConverter postApiConverter)
        {
            _logger = logger;
            _postService = postService;
            _identityUtil = identityUtil;
            _postApiConverter = postApiConverter;
        }

        [HttpDelete]
        [Route("/posts/{id}")]
        public async Task DeletePost(Guid id)
        {
            _logger.LogInformation($"Received delete post request ${id}");
            await _postService.DeletePost(id);
        }


        [HttpPost]
        [Route("/posts")]
        public async Task<Guid> CreatePost(CreatePostRequestDto createPostApiRequest)
        {
            _logger.LogInformation($"Received create post request: ${createPostApiRequest}");
            return await _postService.CreatePost(
                _postApiConverter.ToCreatePostRequest(createPostApiRequest, _identityUtil.GetUserId())
            );
        }

        [HttpPut]
        [Route("/posts/{id}")]
        public async Task UpdatePost(Guid id, UpdatePostRequestDto updatePostApiRequest)
        {
            _logger.LogInformation($"Received update post request: ${id}, ${updatePostApiRequest}");
            await _postService.UpdatePost(
                _postApiConverter.ToUpdatePostRequest(id, _identityUtil.GetUserId(), updatePostApiRequest)
            );
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/posts/search")]
        public async Task<SearchResultDto<SummaryPostDto>> SearchPosts(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            _logger.LogInformation($"Received search posts request: ${searchPostRequestDto}");
            return _postApiConverter.ToSearchPostResultDto(
                await _postService.SearchPosts(_postApiConverter.ToSearchPostRequest(searchPostRequestDto)));
        }


        [HttpPost]
        [Route("/posts/admin/search")]
        public async Task<SearchResultDto<AdminPostDto>> SearchAdminPosts(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            _logger.LogInformation($"Received admin search posts request: ${searchPostRequestDto}");
            return _postApiConverter.ToSearchPostResultDto(
                await _postService.SearchAdminPosts(_postApiConverter.ToSearchPostRequest(searchPostRequestDto)));
        }


        [HttpGet]
        [Route("/posts/{id}")]
        public async Task<UpdatePostDto> GetUpdatePost(Guid id)
        {
            _logger.LogInformation($"Received get post for updating request: ${id}");
            return _postApiConverter.ToUpdatePostDto(await _postService.GetUpdatePost(id));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/posts")]
        public async Task<CompletePostDto> GetPost([FromQuery] string title)
        {
            _logger.LogInformation($"Received get post request: ${title}");
            return _postApiConverter.ToPostDto(await _postService.GetPost(_postApiConverter.toTitle(title)));
        }
    }
}
