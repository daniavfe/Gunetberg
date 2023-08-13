namespace Gunetberg.Domain.Post
{
    public class UpdatePost
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public IEnumerable<Guid> Tags { get; set; }

    }
}
