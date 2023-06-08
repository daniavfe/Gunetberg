using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Port.Input
{
    public interface IPostService
    {
        public IEnumerable<SummaryPost> GetPosts();

        public SearchResult<SummaryPost> SearchPosts(SearchRequest<PostFilterRequest> searchRequest);

        public Guid CreatePost(CreatePostRequest createPostRequest);

        public CompletePost GetPost(Guid id);
    }
}
