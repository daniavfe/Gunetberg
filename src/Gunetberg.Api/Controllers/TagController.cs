using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Tag;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagService _tagService;
        private readonly TagApiConverter _tagApiConverter;

        public TagController(ILogger<TagController> logger, ITagService tagService, TagApiConverter tagApiConverter)
        {
            _logger = logger;
            _tagService = tagService;
            _tagApiConverter = tagApiConverter;
        }


        [HttpPost]
        [Route("/tags")]
        [AllowAnonymous]
        [SwaggerOperation(OperationId = "CreateTags")]
        public async Task CreateTags(IEnumerable<CreateTagRequestDto> createTagRequestDto)
        {
            _logger.LogInformation($"Received create tags request {createTagRequestDto}");
            await _tagService.CreateTags(_tagApiConverter.ToCreateTagRequest(createTagRequestDto));
        }


        [HttpGet]
        [Route("/tags")]
        [AllowAnonymous]
        [SwaggerOperation(OperationId = "GetTags")]
        public async Task<IEnumerable<TagDto>> GetTags()
        {
            _logger.LogInformation($"Received get tags request");
            return _tagApiConverter.ToTagsDto(await _tagService.GetTags());
        }
    }
}
