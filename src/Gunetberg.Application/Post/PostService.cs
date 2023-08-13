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

        public async Task DeletePost(Guid id)
        {
            await _postRepository.DeletePost(id);
        }

        public async Task<Guid> CreatePost(CreatePostRequest createPostRequest)
        {
            var validator = new CreatePostRequestValidator();
            validator.Validate(createPostRequest, options => options.ThrowOnFailures());

            return await _postRepository.CreatePostAsync(createPostRequest);
        }

        public async Task<UpdatePost> GetUpdatePost(Guid id)
        {
            return await _postRepository.GetUpdatePostAsync(id);
        }

        public async Task<CompletePost> GetPost(string title)
        {
            return await _postRepository.GetPostAsync(title);
        }

        public async Task<SearchResult<SummaryPost>> SearchPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            return await _postRepository.SearchPostsAsync(searchRequest);
        }

        public async Task UpdatePost(UpdatePostRequest updatePostRequest)
        {
            await _postRepository.UpdatePostAsync(updatePostRequest);
        }

        public async Task<SearchResult<AdminPost>> SearchAdminPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            return await _postRepository.SearchAdminPostsAsync(searchRequest);
        }
    }
}
