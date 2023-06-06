namespace Gunetberg.Domain.Post
{
    public class SummaryPost
    {
        public Guid Id { get; set; }

        public string Language { get; set; }

        public string Title { get; set; }

        public string SummaryContent { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
