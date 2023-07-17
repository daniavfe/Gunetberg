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
            return createTagsRequestDto.Select(it => ToDomain(it));
        }

        public SimpleTagDto ToSimpleTagDto(SimpleTag simpleTag)
        {
            return new SimpleTagDto
            {
                Id = simpleTag.Id,
                Name = simpleTag.Name
            };
        }

        public IEnumerable<SimpleTagDto> ToSimpleTagsDto(IEnumerable<SimpleTag> simpleTags)
        {
            return simpleTags.Select(x=> ToSimpleTagDto(x));
        }
    }
}
