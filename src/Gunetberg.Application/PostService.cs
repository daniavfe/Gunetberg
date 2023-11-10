using FluentValidation;
using Gunetberg.Application.Validators;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Application
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IPostRepository _postRepository;

        public PostService(ILogger<PostService> logger, IPostRepository postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task DeletePost(Guid id)
        {
            _logger.LogInformation("Removing post");
            await _postRepository.DeletePost(id);
        }

        public async Task<Guid> CreatePost(CreatePostRequest createPostRequest)
        {
            _logger.LogInformation("Validating post creation");
            var validator = new CreatePostRequestValidator();
            validator.Validate(createPostRequest, options => options.ThrowOnFailures());

            _logger.LogInformation($"Creating post in database");
            return await _postRepository.CreatePostAsync(createPostRequest);
        }

        public async Task<UpdatePost> GetUpdatePost(Guid id)
        {
            _logger.LogInformation($"Getting update post from database");
            return await _postRepository.GetUpdatePostAsync(id);
        }

        public async Task<CompletePost> GetPost(string title)
        {
            _logger.LogInformation($"Getting post from database");
            return await _postRepository.GetPostAsync(title);
        }

        public async Task<SearchResult<SummaryPost>> SearchPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            _logger.LogInformation($"Searching posts from database");
            return await _postRepository.SearchPostsAsync(searchRequest);
        }

        public async Task UpdatePost(UpdatePostRequest updatePostRequest)
        {
            _logger.LogInformation($"Updating post to database");
            await _postRepository.UpdatePostAsync(updatePostRequest);
        }

        public async Task<SearchResult<AdminPost>> SearchAdminPosts(SearchRequest<PostFilterRequest, PostFilterSortField> searchRequest)
        {
            _logger.LogInformation($"Getting admin posts from database");
            return await _postRepository.SearchAdminPostsAsync(searchRequest);
        }
    }
}
