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


        public IEnumerable<CreateTagRequest> ToDomain(IEnumerable<CreateTagRequestDto> createTagsRequestDto)
        {
            return createTagsRequestDto.Select(it => ToDomain(it));
        }
    }
}
