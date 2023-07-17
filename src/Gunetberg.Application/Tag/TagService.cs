using Gunetberg.Domain.Tag;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application.Tag
{
    public class TagService: ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Guid> CreateTag(CreateTagRequest createTagRequest)
        {
            return await _tagRepository.CreateTag(createTagRequest);
        }


        public async Task CreateTags(IEnumerable<CreateTagRequest> createTagsRequest)
        {
            await _tagRepository.CreateTags(createTagsRequest);
        }

        public async Task<IEnumerable<SimpleTag>> GetTags()
        {
            return await _tagRepository.GetTags();
        }
    }
}
