using Gunetberg.Domain.Tag;

namespace Gunetberg.Port.Input
{
    public interface ITagService
    {
        Task<Guid> CreateTag(CreateTagRequest createTagRequest);

        Task CreateTags(IEnumerable<CreateTagRequest> createTagsRequest);

        Task<IEnumerable<Tag>> GetTags();
    }
}
