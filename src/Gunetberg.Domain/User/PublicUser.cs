namespace Gunetberg.Domain.User
{
    public class PublicUser
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
