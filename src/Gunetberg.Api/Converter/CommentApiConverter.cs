using Gunetberg.Api.Dto.Comment;
using Gunetberg.Domain.Comment;

namespace Gunetberg.Api.Converter
{
    public class CommentApiConverter
    {
        private readonly UserApiConverter _userApiconverter;

        public CommentApiConverter(UserApiConverter userApiconverter)
        {
            _userApiconverter = userApiconverter;
        }
        public IEnumerable<CommentDto> ToCommentsDto(IEnumerable<Comment> comments)
        {
            return comments.Select(ToCommentDto);
        }

        public CommentDto ToCommentDto(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                CreatedAt = comment.CreatedAt,
                CreatedBy = _userApiconverter.ToPublicUserDto(comment.CreatedBy),
                Content = comment.Content,
            };
        }

        public CreateCommentRequest ToCreateCommentRequest(Guid userId, Guid postId, Guid? commentId, CreateCommentRequestDto createCommentRequest)
        {
            return new CreateCommentRequest
            {
                UserId = userId,
                PostId = postId,
                CommentId = commentId,
                Content = createCommentRequest.Content
            };
        }
    }
}
