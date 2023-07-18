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

        public async Task<Guid> CreatePostAsync(CreatePostRequest createPostRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();
            var post = new PostEntity
            {
                Language = createPostRequest.Language,
                Title = createPostRequest.Title,
                ImageUrl = createPostRequest.ImageUrl,
                Content = createPostRequest.Content,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createPostRequest.CreatedBy,

            };

            if (createPostRequest.Tags != null && createPostRequest.Tags.Any())
            {
                post.PostTags = createPostRequest.Tags.Select(x => new PostTagEntity { PostId = post.Id, TagId = x }).ToList();
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
                    CreatedAt = x.CreatedAt,
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

        public async Task<SearchResult<SummaryPost>> SearchPostsAsync(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
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

            var query = context.Posts.Include(x=>x.PostTags).AsQueryable();

            if (filterByTag != null && filterByTag.Any())
            {
                query = context.PostTags.Where(x => filterByTag.Contains(x.TagId)).Select(x=>x.Post).Distinct().AsQueryable();
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

            return new SearchResult<SummaryPost>
            {
                Page = pagination.Page,
                Pages = pagination.Pages,
                SortByDescending = searchRequest.SortByDescending,
                SortingField = searchRequest.SortField.ToString(),
                ItemsPerPage = pagination.ItemsPerPage,
                Items = await query.Select(x => new SummaryPost
                {
                    Id = x.Id,
                    Summary = x.Content.Substring(0, 150),
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    Language = x.Language,
                    ImageUrl = x.ImageUrl,
                    Tags = x.PostTags.Select(x => new SimpleTag
                    {
                        Id = x.Tag.Id,
                        Name = x.Tag.Name
                    })
                }).ToListAsync()
            };
        }

        public async Task UpdatePostAsync(UpdatePostRequest updatePostRequest)
        {
            await Task.Run(() => null);
        }

    }
}
