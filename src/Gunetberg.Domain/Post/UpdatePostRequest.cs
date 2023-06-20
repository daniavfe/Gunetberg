
namespace Gunetberg.Domain.Post
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
