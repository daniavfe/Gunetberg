using Gunetberg.Api.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Comment
{
    public class CommentDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public PublicUserDto CreatedBy { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
