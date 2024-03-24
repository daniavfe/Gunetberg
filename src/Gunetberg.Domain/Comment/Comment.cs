using Gunetberg.Domain.User;

namespace Gunetberg.Domain.Comment
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public PublicUser CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public int NumberOfReplies { get; set; }
    }
}
