using Gunetberg.Domain.Tag;

namespace Gunetberg.Port.Output.Repository
{
    public interface ITagRepository
    {
        Task<Guid> CreateTag(CreateTagRequest createTagRequest);

        Task CreateTags(IEnumerable<CreateTagRequest> createTagsRequest);

        Task<IEnumerable<SimpleTag>> GetTags();
    }
}
