using System.ComponentModel.DataAnnotations;

namespace Gunetberg.Api.Dto.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        public string Content { get; set; }
    }
}
