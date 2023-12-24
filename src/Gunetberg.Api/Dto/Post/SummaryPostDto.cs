using Gunetberg.Api.Dto.Tag;
using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Post
{
    public class SummaryPostDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public IEnumerable<TagDto> Tags { get; set; }
    }
}
