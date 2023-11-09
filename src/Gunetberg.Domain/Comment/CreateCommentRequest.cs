namespace Gunetberg.Domain.Comment
{
    public class CreateCommentRequest
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public Guid? CommentId { get; set; }
        public string Content { get; set; }
    }
}
