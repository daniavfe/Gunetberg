using Gunetberg.Domain.Post;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
                _postRepository = postRepository;
        }

        public Guid CreatePost(CreatePostRequest createPostRequest)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PostSummary> GetPosts()
        {
            throw new NotImplementedException();
        }

        public SearchPostResult SearchPost(SearchPostRequest searchPostRequest)
        {
            throw new NotImplementedException();
        }
    }
}
