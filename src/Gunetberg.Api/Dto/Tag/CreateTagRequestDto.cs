﻿using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Tag
{
    public class CreateTagRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
