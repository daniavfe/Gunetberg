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

        public Task<Guid> CreatePost(CreatePostRequest createPostRequest)
        {
            var validator = new CreatePostRequestValidator();
            validator.Validate(createPostRequest, options => options.ThrowOnFailures());

            return _postRepository.CreatePostAsync(createPostRequest);
        }

        public Task UpdatePost(UpdatePostRequest updatePostRequest)
        {
            var validator = new UpdatePostRequestValidator();
            validator.Validate(updatePostRequest, options => options.ThrowOnFailures());

            return _postRepository.UpdatePostAsync(updatePostRequest);
        }

        public Task<CompletePost> GetPost(Guid id)
        {
            return _postRepository.GetPostAsync(id);
        }

        public Task<SearchResult<SummaryPost>> SearchPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            return _postRepository.SearchPostsAsync(searchRequest);
        }
    }
}
