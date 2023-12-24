
using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.User
{
    public class UpdateUserPhotoRequestDto
    {
        [Required]
        public string PhotoUrl { get; set; }
    }
}
