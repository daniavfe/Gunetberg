namespace Gunetberg.Api.Dto.Post
{
    public class CreatePostRequestDto
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public string? ImageUrl { get; set; }
        public string Content { get; set; }
    }
}
