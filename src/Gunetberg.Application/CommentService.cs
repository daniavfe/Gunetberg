using Gunetberg.Domain.Comment;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;


namespace Gunetberg.Application
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Guid> CreateComment(CreateCommentRequest createCommentRequest)
        {
            return await _commentRepository.CreateCommentAsync(createCommentRequest);
        }

        public async Task<IEnumerable<Comment>> GetComments(Guid postId, Guid? commentId)
        {
            return await _commentRepository.GetCommentsAsync(postId, commentId);
        }
    }
}
