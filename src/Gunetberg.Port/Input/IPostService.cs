using Gunetberg.Domain.Post;

namespace Gunetberg.Port.Input
{
    public interface IPostService
    {
        public List<PostSummary> GetPosts();

        public SearchPostResult SearchPost(SearchPostRequest searchPostRequest);

        public Guid CreatePost(CreatePostRequest createPostRequest);

        public Post GetPost(Guid id);
    }
}
