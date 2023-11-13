using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Comment;
using Gunetberg.Api.Dto.Common;
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
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;
        private readonly CommentApiConverter _commentApiConverter;
        private readonly IdentityUtil _identityUtil;
        public CommentController(ILogger<CommentController> logger, ICommentService commentService, CommentApiConverter commentApiConverter, IdentityUtil identityUtil)
        {
            _logger = logger;
            _commentService = commentService;
            _commentApiConverter = commentApiConverter;
            _identityUtil = identityUtil;
        }

        [HttpPost]
        [Route("/posts/{postId}/comments")]
        public async Task<Guid> CreateComment(CreateCommentRequestDto createCommentRequest, Guid postId, Guid? commentId)
        {
            _logger.LogInformation($"Received create comment request: {createCommentRequest}, {postId}, {commentId}");
            return await _commentService.CreateComment(_commentApiConverter.ToCreateCommentRequest(_identityUtil.GetUserId(), postId, commentId, createCommentRequest));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/posts/{postId}/comments")]
        public async Task<PaginationResultDto<CommentDto>> GetComments(Guid postId, Guid? commentId, int page, int itemsPerPage)
        {
            _logger.LogInformation($"Received get comments request: {postId}, {commentId}");
            return _commentApiConverter.ToPaginationCommentsResultDto(await _commentService.GetComments(postId, commentId, page, itemsPerPage));
        }
    }
}
