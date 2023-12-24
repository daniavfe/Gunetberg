using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Post
{
    public class UpdatePostDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public IEnumerable<Guid> Tags { get; set; }
    }
}
