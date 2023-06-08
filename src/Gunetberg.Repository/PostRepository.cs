using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Repository
{
    public class PostRepository : IPostRepository
    {
        public Guid CreatePost(CreatePostRequest createPostRequest)
        {
            throw new NotImplementedException();
        }

        public CompletePost GetPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SummaryPost> GetPosts()
        {
            throw new NotImplementedException();
        }

        public SearchResult<SummaryPost> SearchPosts(SearchRequest<PostFilterRequest> searchRequest)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(UpdatePostRequest updatePostRequest)
        {
            throw new NotImplementedException();
        }
    }
}
