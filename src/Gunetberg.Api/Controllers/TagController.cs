using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Tag;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TagController: ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly TagApiConverter _tagApiConverter;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
            _tagApiConverter = new TagApiConverter();
        }


        [HttpPost]
        [Route("/tags")]
        [AllowAnonymous]
        public async Task CreateTags(IEnumerable<CreateTagRequestDto> createTagRequestDto)
        {
            await _tagService.CreateTags(_tagApiConverter.ToDomain(createTagRequestDto));
        }
    }
}
