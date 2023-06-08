namespace Gunetberg.Domain.User
{
    public class User
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Alias { get; set; }

        public string? Description { get; set; }

        public string? PhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
