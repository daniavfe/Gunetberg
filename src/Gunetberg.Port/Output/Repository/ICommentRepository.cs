using Gunetberg.Domain.Comment;

namespace Gunetberg.Port.Output.Repository
{
    public interface ICommentRepository
    {
        Task<Guid> CreateCommentAsync(CreateCommentRequest createCommentRequest);
        Task<IEnumerable<Comment>> GetCommentsAsync(Guid postId, Guid? commentId);
    }
}
