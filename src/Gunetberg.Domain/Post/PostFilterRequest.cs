

namespace Gunetberg.Domain.Post
{
    public class PostFilterRequest
    {
        public string FilterByTitle { get; set; }
        public IEnumerable<Guid> FilterByTags { get; set; }
    }
}
