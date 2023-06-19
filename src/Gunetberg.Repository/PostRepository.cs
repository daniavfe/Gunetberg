using Dapper;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Configuration;

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

        public Task<CompletePost> GetPostAsync(Guid id)
        {
            throw new NotImplementedException();
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

                var numberOfEntries = await con.ExecuteScalarAsync<int>(countQuery.RawSql);


                var availableItems = numberOfEntries;

                var selectedItemsPerPage = (searchRequest.ItemsPerPage != null &&  searchRequest?.ItemsPerPage >= 10 && searchRequest?.ItemsPerPage <= 25) ? searchRequest.ItemsPerPage.Value : 10;

                var availablePages = Math.Max((int)Math.Ceiling( availableItems / (decimal) selectedItemsPerPage), 1);

                var selectedPage = (searchRequest.Page != null && searchRequest.Page <= availablePages && searchRequest.Page > 0) ? searchRequest.Page.Value : availablePages;

                var selectQuery = new SqlBuilder()
                    .Select("*")
                    .Where($"Title LIKE '%{searchRequest?.FilterRequest?.FilterByTitle}%'")
                    .OrderBy($"{searchRequest.SortField} {descending}")
                    .AddTemplate($"Select /**select**/ FROM POSTS /**where**/ /**orderby**/ " +
                        $"OFFSET {(selectedPage - 1) * selectedItemsPerPage} ROWS FETCH NEXT {selectedItemsPerPage} ROWS ONLY");


                var items = await con.QueryAsync<SummaryPost>(selectQuery.RawSql);

                return new SearchResult<SummaryPost>
                {
                    Page = selectedPage,
                    Pages = availablePages,
                    ItemsPerPage = selectedItemsPerPage,
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
