namespace Gunetberg.Api.Dto.Post
{
    public class UpdatePostDto
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
