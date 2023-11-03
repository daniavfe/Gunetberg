using Gunetberg.Domain.Comment;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Context;
using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private RepositoryContextFactory _repositoryContextfactory;

        public CommentRepository(RepositoryContextFactory repositoryContextfactory)
        {
            _repositoryContextfactory = repositoryContextfactory;
        }

        public async Task<Guid> CreateCommentAsync(CreateCommentRequest createCommentRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();
            var comment = new CommentEntity
            {
                CreatedAt = DateTime.Now,
                CreatedBy = createCommentRequest.UserId,
                PostId = createCommentRequest.PostId,
                ParentId = createCommentRequest.CommentId,
                Content = createCommentRequest.Content
            };

            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(Guid postId, Guid? commentId)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var query = context.Comments.Include(x => x.User)
                .Where(x => x.PostId == postId).AsQueryable();

            if (commentId.HasValue)
            {
                query = query.Where(x => x.ParentId == commentId);
            }

            return await query.Select(x => new Comment
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt.UtcDateTime,
                Content = x.Content,
                NumberOfReplies = x.SubComments.Count(),
                CreatedBy = new PublicUser
                {
                    Id = x.User.Id,
                    Alias = x.User.Alias,
                    PhotoUrl = x.User.PhotoUrl
                }
            }).ToListAsync();
        }
    }
}
