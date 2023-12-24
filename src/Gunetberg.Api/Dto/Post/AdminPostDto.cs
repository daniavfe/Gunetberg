using Gunetberg.Api.Dto.Tag;
using Gunetberg.Api.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Post
{
    public class AdminPostDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public AdminAuthorDto Author { get; set; }

        [Required]
        public IEnumerable<TagDto> Tags { get; set; }
    }
}
