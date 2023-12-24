using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.User
{
    public class CreateUserRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordCheck { get; set; }
    }
}
