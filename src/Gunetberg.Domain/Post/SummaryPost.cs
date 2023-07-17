using Gunetberg.Domain.Tag;

namespace Gunetberg.Domain.Post
{
    public class SummaryPost
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<SimpleTag>? Tags { get; set; }
    }
}
