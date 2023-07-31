using Gunetberg.Api.Dto.Tag;

namespace Gunetberg.Api.Dto.Post
{
    public class AdminPostDto
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public IEnumerable<SimpleTagDto> Tags { get; set; }
    }
}
