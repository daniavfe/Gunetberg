namespace Gunetberg.Domain.User
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}
