using FluentValidation;
using Gunetberg.Application.Post.Validator;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application.Post
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
            var validator = new CreatePostRequestValidator();
            validator.Validate(createPostRequest, options => options.ThrowOnFailures());

            return _postRepository.CreatePost(createPostRequest);
        }

        public void UpdatePost(UpdatePostRequest updatePostRequest)
        {
            var validator = new UpdatePostRequestValidator();
            validator.Validate(updatePostRequest, options => options.ThrowOnFailures());

            _postRepository.UpdatePost(updatePostRequest);
        }

        public CompletePost GetPost(Guid id)
        {
            return _postRepository.GetPost(id);
        }

        public IEnumerable<SummaryPost> GetPosts()
        {
            return _postRepository.GetPosts();
        }

        public SearchResult<SummaryPost> SearchPosts(SearchRequest<PostFilterRequest> searchRequest)
        {
            return _postRepository.SearchPosts(searchRequest);
        }
    }
}
