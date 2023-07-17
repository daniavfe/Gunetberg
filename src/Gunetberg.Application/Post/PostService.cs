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

        public async Task<Guid> CreatePost(CreatePostRequest createPostRequest)
        {
            var validator = new CreatePostRequestValidator();
            validator.Validate(createPostRequest, options => options.ThrowOnFailures());

            return await _postRepository.CreatePostAsync(createPostRequest);
        }

        public async Task UpdatePost(UpdatePostRequest updatePostRequest)
        {
            var validator = new UpdatePostRequestValidator();
            validator.Validate(updatePostRequest, options => options.ThrowOnFailures());

            await _postRepository.UpdatePostAsync(updatePostRequest);
        }

        public async Task<CompletePost> GetPost(Guid id)
        {
            return await _postRepository.GetPostAsync(id);
        }

        public async Task<SearchResult<SummaryPost>> SearchPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            return await _postRepository.SearchPostsAsync(searchRequest);
        }
    }
}
