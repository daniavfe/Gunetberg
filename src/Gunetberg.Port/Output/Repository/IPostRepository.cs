using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Port.Output.Repository
{
    public interface IPostRepository
    {
        Guid CreatePost(CreatePostRequest createPostRequest);
        CompletePost GetPost(Guid id);
        IEnumerable<SummaryPost> GetPosts();
        SearchResult<SummaryPost> SearchPosts(SearchRequest<PostFilterRequest> searchRequest);
        void UpdatePost(UpdatePostRequest updatePostRequest);
    }
}
