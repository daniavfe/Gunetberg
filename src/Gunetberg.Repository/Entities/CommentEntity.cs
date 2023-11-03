namespace Gunetberg.Repository.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid PostId { get; set; }
        public PostEntity Post { get; set; }
        public Guid CreatedBy { get; set; }
        public UserEntity User { get; set; }
        public Guid? ParentId { get; set; }
        public CommentEntity Parent { get; set; }
        public IEnumerable<CommentEntity> SubComments { get; set; }
    }
}
