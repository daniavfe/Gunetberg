using Gunetberg.Api.Dto.User;

namespace Gunetberg.Api.Dto.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public PublicUserDto CreatedBy { get; set; }
        public string Content { get; set; }
    }
}
