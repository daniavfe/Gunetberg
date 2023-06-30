namespace Gunetberg.Api.Dto.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Description { get; set; }

    }
}
