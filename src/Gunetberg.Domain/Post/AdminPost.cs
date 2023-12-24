using Gunetberg.Domain.Tag;
using Gunetberg.Domain.User;

namespace Gunetberg.Domain.Post
{
    public class AdminPost
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<Tag.Tag>? Tags { get; set; }

        public AdminAuthor Author { get; set; }
    }
}
