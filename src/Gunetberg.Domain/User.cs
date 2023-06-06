namespace Gunetberg.Domain
{
    public class User
    {
        public string Alias { get; set; }

        public string? Description { get; set; }

        public string? PhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
