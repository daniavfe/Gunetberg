namespace Gunetberg.Domain.Post
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public Guid CreatedBy { get; set; }
        public string? ImageUrl { get; set; }
        public string Content { get; set; }
    }
}
