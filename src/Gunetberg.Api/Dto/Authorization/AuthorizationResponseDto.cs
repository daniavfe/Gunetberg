using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Authorization
{
    public class AuthorizationResponseDto
    {
        [Required]
        public string AccessToken { get; set; }
    }
}
