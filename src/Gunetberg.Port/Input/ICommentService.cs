using Gunetberg.Domain.Comment;
using Gunetberg.Domain.Common;

namespace Gunetberg.Port.Input
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CreateCommentRequest createCommentRequest);
        Task<Comment> GetComment(Guid postId, Guid commentId);
        Task<PaginatedResult<Comment>> GetComments(Guid postId, Guid? commentId, int page, int itemsPerPage);
    }
}
