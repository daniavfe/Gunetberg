using FluentValidation;
using Gunetberg.Application.Validators;
using Gunetberg.Domain.Tag;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Application
{
    public class TagService : ITagService
    {
        private readonly ILogger<TagService> _logger;
        private readonly ITagRepository _tagRepository;

        public TagService(ILogger<TagService> logger, ITagRepository tagRepository)
        {
            _logger = logger;
            _tagRepository = tagRepository;
        }

        public async Task<Guid> CreateTag(CreateTagRequest createTagRequest)
        {
            _logger.LogInformation("Validating tag creation");
            var validator = new CreateTagRequestValidator();
            validator.Validate(createTagRequest, options => options.ThrowOnFailures());

            _logger.LogInformation("Creating tag in database");
            return await _tagRepository.CreateTag(createTagRequest);
        }

        public async Task CreateTags(IEnumerable<CreateTagRequest> createTagsRequest)
        {
            _logger.LogInformation("Validating tags creation");
            var validator = new CreateTagRequestValidator();
            createTagsRequest.Select(x => validator.Validate(x, options => options.ThrowOnFailures()));

            _logger.LogInformation("Creating tags in database");
            await _tagRepository.CreateTags(createTagsRequest);
        }

        public async Task<IEnumerable<Tag>> GetTags()
        {
            _logger.LogInformation("Getting tags from database");
            return await _tagRepository.GetTags();
        }
    }
}
