﻿using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Common
{
    public class PaginatedResponseDto<T>
    {
        [Required]
        public int Page { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int TotalItems { get; set; }

        [Required]
        public int ItemsPerPage { get; set; }

        [Required]
        public IEnumerable<T> Items { get; set; }
    }
}
