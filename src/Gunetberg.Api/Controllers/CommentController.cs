using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Comment;
using Gunetberg.Client.Identity;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly CommentApiConverter _commentApiConverter;
        private readonly IdentityUtil _identityUtil;
        public CommentController(ICommentService commentService, CommentApiConverter commentApiConverter, IdentityUtil identityUtil)
        {
            _commentService = commentService;
            _commentApiConverter = commentApiConverter;
            _identityUtil = identityUtil;
        }

        [HttpPost]
        [Route("/posts/{postId}/comments")]
        public async Task<Guid> CreateComment(CreateCommentRequestDto createCommentRequest, Guid postId, Guid? commentId)
        {
            return await _commentService.CreateComment(_commentApiConverter.ToCreateCommentRequest(_identityUtil.GetUserId(), postId, commentId, createCommentRequest));
        }

        [HttpGet]
        [Route("/posts/{postId}/comments")]
        public async Task<IEnumerable<CommentDto>> GetComments(Guid postId, Guid? commentId)
        {
           return _commentApiConverter.ToCommentsDto(await _commentService.GetComments(postId, commentId));
        }
    }
}
