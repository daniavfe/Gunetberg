using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Tag
{
    public class TagDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
