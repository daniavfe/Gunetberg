using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Common
{
    public class PaginationResultDto<T>
    {
        [Required]
        public int Page { get; set; }

        [Required]
        public int ItemsPerPage { get; set; }

        [Required]
        public IEnumerable<T> Items { get; set; }
    }
}
