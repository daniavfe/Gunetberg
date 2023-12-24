using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.User
{
    public class UpdateUserDescriptionRequestDto
    {
        [Required]
        public string Description { get; set; }
    }
}
