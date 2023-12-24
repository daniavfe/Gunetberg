using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Authorization
{
    public class AuthorizationRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
