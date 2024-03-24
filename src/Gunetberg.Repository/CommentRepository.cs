using Gunetberg.Domain.Comment;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Exception;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Context;
using Gunetberg.Repository.Entities;
using Gunetberg.Repository.Util;
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

        public async Task<Comment> GetCommentAsync(Guid postId, Guid commentId)
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Comments.Include(x => x.User)
                .Select( x => new Comment
                {
                    Id = x.Id,
                    PostId = x.PostId,
                    CreatedAt = x.CreatedAt.UtcDateTime,
                    Content = x.Content,
                    NumberOfReplies = x.SubComments.Count(),
                    CreatedBy = new PublicUser
                    {
                        Id = x.User.Id,
                        Alias = x.User.Alias,
                        PhotoUrl = x.User.PhotoUrl
                    }
                })
               .SingleOrDefaultAsync(x => x.PostId == postId && x.Id == commentId) ?? throw new EntityNotFoundException<Comment>();
        }

        public async Task<PaginatedResult<Comment>> GetCommentsAsync(Guid postId, Guid? commentId, int page, int itemsPerPage)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var query = context.Comments.Include(x => x.User)
                .Where(x => x.PostId == postId).AsQueryable();

            if (commentId.HasValue)
            {
                query = query.Where(x => x.ParentId == commentId);
            }
            else
            {
                query = query.Where(x => x.ParentId == null);
            }

            query = query.OrderByDescending(x => x.CreatedAt);

            var totalItems = query.Count();
            var pagination = PaginationUtil.GetPagination(totalItems, page, itemsPerPage);


            query = query.Skip((pagination.Page - 1) * pagination.ItemsPerPage).Take(pagination.ItemsPerPage);

            return new PaginatedResult<Comment>
            {
                Page = pagination.Page,
                Pages = pagination.Pages,
                TotalItems = totalItems,
                ItemsPerPage = pagination.ItemsPerPage,
                Items = await query.Select(x => new Comment
                {
                    Id = x.Id,
                    PostId = x.PostId,
                    CreatedAt = x.CreatedAt.UtcDateTime,
                    Content = x.Content,
                    NumberOfReplies = x.SubComments.Count(),
                    CreatedBy = new PublicUser
                    {
                        Id = x.User.Id,
                        Alias = x.User.Alias,
                        PhotoUrl = x.User.PhotoUrl
                    }
                }).ToListAsync()
            };
        }
    }
}
