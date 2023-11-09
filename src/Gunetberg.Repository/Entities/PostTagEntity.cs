namespace Gunetberg.Repository.Entities
{
    public class PostTagEntity
    {
        public Guid PostId { get; set; }
        public Guid TagId { get; set; }
        public PostEntity Post { get; set; }
        public TagEntity Tag { get; set; }
    }
}
