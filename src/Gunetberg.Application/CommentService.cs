using FluentValidation;
using Gunetberg.Application.Validators;
using Gunetberg.Domain.Comment;
using Gunetberg.Domain.Common;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;
using Microsoft.Extensions.Logging;


namespace Gunetberg.Application
{
    public class CommentService : ICommentService
    {
        private readonly ILogger<CommentService> _logger;
        private readonly ICommentRepository _commentRepository;

        public CommentService(ILogger<CommentService> logger, ICommentRepository commentRepository)
        {
            _logger = logger;
            _commentRepository = commentRepository;
        }

        public async Task<Guid> CreateComment(CreateCommentRequest createCommentRequest)
        {
            _logger.LogInformation("Validating comment creation");
            var validator = new CreateCommentValidator();
            validator.Validate(createCommentRequest, options => options.ThrowOnFailures());
            _logger.LogInformation($"Creating comment in database");
            return await _commentRepository.CreateCommentAsync(createCommentRequest);
        }

        public async Task<Comment> GetComment(Guid postId, Guid commentId)
        {
            _logger.LogInformation("Getting comment from database");
            return await _commentRepository.GetCommentAsync(postId, commentId);
        }

        public async Task<PaginatedResult<Comment>> GetComments(Guid postId, Guid? commentId, int page, int itemsPerPage)
        {
            _logger.LogInformation("Getting comments from database");
            return await _commentRepository.GetCommentsAsync(postId, commentId, page, itemsPerPage);
        }
    }
}
