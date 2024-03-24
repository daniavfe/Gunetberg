using Gunetberg.Domain.Comment;
using Gunetberg.Domain.Common;

namespace Gunetberg.Port.Output.Repository
{
    public interface ICommentRepository
    {
        Task<Guid> CreateCommentAsync(CreateCommentRequest createCommentRequest);
        Task<Comment> GetCommentAsync(Guid postId, Guid commentId);
        Task<PaginatedResult<Comment>> GetCommentsAsync(Guid postId, Guid? commentId, int page, int itemsPerPage);
    }
}
