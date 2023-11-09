namespace Gunetberg.Repository.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
        public UserEntity User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public IEnumerable<PostTagEntity> PostTags { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
    }
}
