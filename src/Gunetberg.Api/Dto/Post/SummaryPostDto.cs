using Gunetberg.Api.Dto.Tag;

namespace Gunetberg.Api.Dto.Post
{
    public class SummaryPostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Summary { get; set; }
        public string Language { get; set; }
        public IEnumerable<SimpleTagDto> Tags { get; set; }
    }
}
