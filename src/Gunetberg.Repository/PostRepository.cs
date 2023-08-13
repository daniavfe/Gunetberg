using Gunetberg.Domain.Common;
using Gunetberg.Domain.Exception;
using Gunetberg.Domain.Post;
using Gunetberg.Domain.Tag;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Context;
using Gunetberg.Repository.Entities;
using Gunetberg.Repository.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Gunetberg.Repository
{
    public class PostRepository : IPostRepository
    {
        private RepositoryContextFactory _repositoryContextfactory;

        public PostRepository(RepositoryContextFactory repositoryContextfactory)
        {
            _repositoryContextfactory = repositoryContextfactory;
        }

        public async Task<Guid> CreatePostAsync(CreatePostRequest createOrUpdatePostRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();
            var post = new PostEntity
            {
                Language = createOrUpdatePostRequest.Language,
                Title = createOrUpdatePostRequest.Title,
                ImageUrl = createOrUpdatePostRequest.ImageUrl,
                Content = createOrUpdatePostRequest.Content,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createOrUpdatePostRequest.CreatedBy,

            };

            if (createOrUpdatePostRequest.Tags != null && createOrUpdatePostRequest.Tags.Any())
            {
                post.PostTags = createOrUpdatePostRequest.Tags.Select(x => new PostTagEntity { PostId = post.Id, TagId = x }).ToList();
            }

            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return post.Id;

        }

        public async Task<CompletePost> GetPostAsync(Guid id)
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Posts
                .Select(x => new CompletePost
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt.UtcDateTime,
                    Title = x.Title,
                    Language = x.Language,
                    ImageUrl = x.ImageUrl,
                    Tags = x.PostTags.Select(x => new SimpleTag
                    {
                        Id = x.Tag.Id,
                        Name = x.Tag.Name
                    }),
                    Author = new Author
                    {
                        Id = x.Author.Id,
                        Alias = x.Author.Alias,
                        PhotoUrl = x.Author.PhotoUrl,
                        Description = x.Author.Description,
                    }
                })
                .SingleOrDefaultAsync(post => post.Id == id) ?? throw new EntityNotFoundException<CompletePost>();
        }

        public async Task<CompletePost> GetPostAsync(string title)
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Posts
                .Select(x => new CompletePost
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt.UtcDateTime,
                    Title = x.Title,
                    Language = x.Language,
                    ImageUrl = x.ImageUrl,
                    Tags = x.PostTags.Select(x => new SimpleTag
                    {
                        Id = x.Tag.Id,
                        Name = x.Tag.Name
                    }),
                    Author = new Author
                    {
                        Id = x.Author.Id,
                        Alias = x.Author.Alias,
                        PhotoUrl = x.Author.PhotoUrl,
                        Description = x.Author.Description,
                    }
                })
                .SingleOrDefaultAsync(post => post.Title.ToLower() == title.ToLower()) ?? throw new EntityNotFoundException<CompletePost>();
        }

        public async Task DeletePost(Guid id)
        {
            var context = _repositoryContextfactory.GetDBContext();
            var post = await context.Posts.SingleOrDefaultAsync(x => x.Id == id) ?? throw new EntityNotFoundException<CompletePost>();
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(UpdatePostRequest updatePostRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var existingPost = await context.Posts.SingleOrDefaultAsync(x => x.Id == updatePostRequest.Id && x.CreatedBy == updatePostRequest.CreatedBy)
                ?? throw new EntityNotFoundException<CompletePost>();

            existingPost.Title = updatePostRequest.Title;
            existingPost.Content = updatePostRequest.Content;
            existingPost.ImageUrl = updatePostRequest.ImageUrl;
            existingPost.Language = updatePostRequest.Language;

            if (updatePostRequest.Tags != null)
            {
                existingPost.PostTags = updatePostRequest.Tags.Select(x => new PostTagEntity { PostId = existingPost.Id, TagId = x }).ToList();
            }

            context.Posts.Update(existingPost);
            await context.SaveChangesAsync();
        }

        public async Task<SearchResult<SummaryPost>> SearchPostsAsync(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            return await SearchPostsAsync(searchRequest, (postEntity) => new SummaryPost
            {
                Id = postEntity.Id,
                Summary = postEntity.Summary,
                CreatedAt = postEntity.CreatedAt.UtcDateTime,
                Title = postEntity.Title,
                Language = postEntity.Language,
                ImageUrl = postEntity.ImageUrl,
                Tags = postEntity.PostTags.Select(x => new SimpleTag
                {
                    Id = x.Tag.Id,
                    Name = x.Tag.Name
                })
            });
        }

        public async Task<SearchResult<AdminPost>> SearchAdminPostsAsync(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            return await SearchPostsAsync(searchRequest, (postEntity) => new AdminPost
            {
                Id = postEntity.Id,
                CreatedAt = postEntity.CreatedAt.UtcDateTime,
                Title = postEntity.Title,
                Language = postEntity.Language,
                Author = new AdminAuthor
                {
                    Id = postEntity.Author.Id,
                    Alias = postEntity.Author.Alias,
                    Email = postEntity.Author.Email
                },
                Tags = postEntity.PostTags.Select(x => new SimpleTag
                {
                    Id = x.Tag.Id,
                    Name = x.Tag.Name
                })
            });
        }

        private async Task<SearchResult<T>> SearchPostsAsync<T>(
            SearchRequest<PostFilterRequest, PostFilterSortField> 
            searchRequest, Func<PostEntity, T> mapper)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var filterByTitle = searchRequest.FilterRequest.FilterByTitle.Trim();
            var filterByTag = searchRequest.FilterRequest.FilterByTags;


            var postCountQuery = context.Posts.AsQueryable();

            if (filterByTag != null && filterByTag.Any())
            {
                postCountQuery = context.PostTags.Where(x => filterByTag.Contains(x.TagId)).Select(x => x.Post).Distinct().AsQueryable();
            }

            if (!string.IsNullOrEmpty(filterByTitle))
            {
                postCountQuery = postCountQuery.Where(x => x.Title.Contains(filterByTitle));
            }

            var pagination = PaginationUtil.GetPagination(postCountQuery.Count(), searchRequest.Page, searchRequest.ItemsPerPage);

            var query = context.Posts
                .Include(x => x.PostTags)
                .ThenInclude(x => x.Tag)
                .Include(x=>x.Author).AsQueryable();

            if (filterByTag != null && filterByTag.Any())
            {
                query = context.PostTags.Where(x => filterByTag.Contains(x.TagId)).Select(x => x.Post)
                    .Distinct()
                    .Include(x => x.PostTags)
                    .ThenInclude(x => x.Tag)
                    .Include(x => x.Author).AsQueryable();
            }

            if (!filterByTitle.IsNullOrEmpty())
            {
                query = query.Where(x => x.Title.Contains(filterByTitle));
            }

            if (searchRequest.SortByDescending)
            {
                switch (searchRequest.SortField)
                {
                    case PostFilterSortField.Title:
                        query = query.OrderByDescending(x => x.Title);
                        break;
                    case PostFilterSortField.Language:
                        query = query.OrderByDescending(x => x.Language);
                        break;
                    case PostFilterSortField.CreatedAt:
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }
            else
            {
                switch (searchRequest.SortField)
                {
                    case PostFilterSortField.Title:
                        query = query.OrderBy(x => x.Title);
                        break;
                    case PostFilterSortField.Language:
                        query = query.OrderBy(x => x.Language);
                        break;
                    case PostFilterSortField.CreatedAt:
                        query = query.OrderBy(x => x.CreatedAt);
                        break;
                }
            }

            query = query.Skip((pagination.Page - 1) * pagination.ItemsPerPage).Take(pagination.ItemsPerPage);

            return new SearchResult<T>
            {
                Page = pagination.Page,
                Pages = pagination.Pages,
                SortByDescending = searchRequest.SortByDescending,
                SortingField = searchRequest.SortField.ToString(),
                ItemsPerPage = pagination.ItemsPerPage,
                Items = await query.Select(x=> mapper(x)).ToListAsync()
            };
        }


    }
}
