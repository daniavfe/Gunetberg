namespace Gunetberg.Domain.User
{
    public class AuthorizationUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string Alias { get; set; }
    }
}
