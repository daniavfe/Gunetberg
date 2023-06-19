using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Port.Input
{
    public interface IPostService
    {
        public Task<SearchResult<SummaryPost>> SearchPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest);

        public Task<Guid> CreatePost(CreatePostRequest createPostRequest);

        public Task<CompletePost> GetPost(Guid id);
    }
}
