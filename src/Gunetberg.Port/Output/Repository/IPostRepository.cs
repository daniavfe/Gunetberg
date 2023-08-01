using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Port.Output.Repository
{
    public interface IPostRepository
    {
        Task<Guid> CreatePostAsync(CreatePostRequest createOrUpdatePostRequest);
        Task DeletePost(Guid id);
        Task<CompletePost> GetPostAsync(Guid id);
        Task<CompletePost> GetPostAsync(string title);
        Task<SearchResult<AdminPost>> SearchAdminPostsAsync(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest);
        Task<SearchResult<SummaryPost>> SearchPostsAsync(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest);
        Task UpdatePostAsync(UpdatePostRequest updatePostRequest);
    }
}
