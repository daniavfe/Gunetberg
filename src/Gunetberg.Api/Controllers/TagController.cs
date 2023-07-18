﻿using Gunetberg.Api.Converter;
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

        public TagController(ITagService tagService, TagApiConverter tagApiConverter)
        {
            _tagService = tagService;
            _tagApiConverter = tagApiConverter;
        }


        [HttpPost]
        [Route("/tags")]
        [AllowAnonymous]
        public async Task CreateTags(IEnumerable<CreateTagRequestDto> createTagRequestDto)
        {
            await _tagService.CreateTags(_tagApiConverter.ToCreateTagRequest(createTagRequestDto));
        }


        [HttpGet]
        [Route("/tags")]
        [AllowAnonymous]
        public async Task<IEnumerable<SimpleTagDto>> GetTags()
        {
            return  _tagApiConverter.ToSimpleTagsDto(await _tagService.GetTags());
        }
    }
}
