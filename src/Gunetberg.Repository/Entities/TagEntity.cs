namespace Gunetberg.Repository.Entities
{
    public class TagEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<PostTagEntity> PostTags { get; set; }
    }
}
