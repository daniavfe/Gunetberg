using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.User
{
    public class PublicUserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Alias { get; set; }
        public string? PhotoUrl { get; set; }

    }
}
