using Gunetberg.Domain.Tag;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Context;
using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Repository
{
    public class TagRepository : ITagRepository
    {
        private RepositoryContextFactory _repositoryContextfactory;

        public TagRepository(RepositoryContextFactory repositoryContextfactory)
        {
            _repositoryContextfactory = repositoryContextfactory;
        }

        public async Task<Guid> CreateTag(CreateTagRequest createTagRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var tag = new TagEntity
            {
                Name = createTagRequest.Name,
                CreatedAt = DateTime.UtcNow,
            };
            context.Tags.Add(tag);
            await context.SaveChangesAsync();

            return tag.Id;
        }

        public async Task CreateTags(IEnumerable<CreateTagRequest> createTagsRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();

            foreach (var createTagRequest in createTagsRequest)
            {
                context.Tags.Add(new TagEntity
                {
                    Name = createTagRequest.Name,
                    CreatedAt = DateTime.UtcNow,
                });
            }

            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<SimpleTag>> GetTags()
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Tags.Select(x => new SimpleTag
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
