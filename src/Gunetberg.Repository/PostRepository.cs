using Dapper;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Exception;
using Gunetberg.Domain.Post;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Configuration;
using Gunetberg.Repository.Util;

namespace Gunetberg.Repository
{
    public class PostRepository : IPostRepository
    {
        private IConnectionFactory _connectionFactory;
       

        public PostRepository(IConnectionFactory connectionFactory)
        {
                _connectionFactory = connectionFactory;
        }

        public Task<Guid> CreatePostAsync(CreatePostRequest createPostRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<CompletePost> GetPostAsync(Guid id)
        {
            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                var query = new SqlBuilder()
                           .Select("*")
                           .Where($"Id = @Id")
                           .AddTemplate("Select /**select**/ FROM POSTS /**where**/");

                return await con.QuerySingleOrDefaultAsync<CompletePost>(query.RawSql, new { Id = id }) 
                    ?? throw new EntityNotFoundException<CompletePost>();
            }
        }

        public async Task<SearchResult<SummaryPost>> SearchPostsAsync(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {

            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                
                var descending = searchRequest.SortByDescending ? "DESC" : string.Empty;

                var countQuery = new SqlBuilder()
                            .Select("COUNT(*)")
                            .Where($"Title LIKE '%{searchRequest?.FilterRequest?.FilterByTitle}%'")
                            .AddTemplate("Select /**select**/ FROM POSTS /**where**/");

                var availableItems = await con.ExecuteScalarAsync<int>(countQuery.RawSql);

                var pagination = PaginationUtil.GetPagination(availableItems, searchRequest.Page, searchRequest.ItemsPerPage);


                var selectQuery = new SqlBuilder()
                    .Select("Id, Language, Title, LEFT(Content, 100) as Summary, CreatedAt")
                    .Where($"Title LIKE '%{searchRequest?.FilterRequest?.FilterByTitle}%'")
                    .OrderBy($"{searchRequest.SortField} {descending}")
                    .AddTemplate($"Select /**select**/ FROM POSTS /**where**/ /**orderby**/ " +
                        $"OFFSET {(pagination.Page - 1) * pagination.ItemsPerPage} ROWS FETCH NEXT {pagination.ItemsPerPage} ROWS ONLY");


                var items = await con.QueryAsync<SummaryPost>(selectQuery.RawSql);

                return new SearchResult<SummaryPost>
                {
                    Page = pagination.Page,
                    Pages = pagination.Pages,
                    ItemsPerPage = pagination.ItemsPerPage,
                    SortByDescending = searchRequest.SortByDescending,
                    SortingField = searchRequest?.SortField.ToString(),
                    Items = items
                };

            }

            
        }

        public Task UpdatePostAsync(UpdatePostRequest updatePostRequest)
        {
            throw new NotImplementedException();
        }
    }
}
