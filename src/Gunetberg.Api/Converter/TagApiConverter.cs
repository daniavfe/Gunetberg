using Gunetberg.Api.Dto.Tag;
using Gunetberg.Domain.Tag;

namespace Gunetberg.Api.Converter
{
    public class TagApiConverter
    {
        public CreateTagRequest ToDomain(CreateTagRequestDto createTagRequestDto)
        {
            return new CreateTagRequest
            {
                Name = createTagRequestDto.Name
            };
        }

        public IEnumerable<CreateTagRequest> ToCreateTagRequest(IEnumerable<CreateTagRequestDto> createTagsRequestDto)
        {
            return createTagsRequestDto.Select(ToDomain);
        }

        public TagDto ToTagDto(Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public IEnumerable<TagDto> ToTagsDto(IEnumerable<Tag> tags)
        {
            return tags.Select(ToTagDto);
        }
    }
}
