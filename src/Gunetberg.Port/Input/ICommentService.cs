using Gunetberg.Domain.Comment;

namespace Gunetberg.Port.Input
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CreateCommentRequest createCommentRequest);

        Task<IEnumerable<Comment>> GetComments(Guid postId, Guid? commentId);
    }
}
