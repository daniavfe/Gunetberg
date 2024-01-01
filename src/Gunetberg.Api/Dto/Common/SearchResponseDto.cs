using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Common
{
    public class SearchResponseDto<T>: PaginatedResponseDto<T>
    {

        [Required]
        public string SortingField { get; set; }

        [Required]
        public bool SortByDescending { get; set; }

        [Required]
        public IEnumerable<T> Items { get; set; }
    }
}
