namespace Gunetberg.Api.Dto.Post
{
    public class PostFilterRequestDto
    {
        public string? FilterByTitle { get; set; }
        public IEnumerable<Guid>? FilterByTags { get; set; }
    }
}
