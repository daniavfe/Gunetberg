namespace Gunetberg.Domain.User
{
    public class HashedCreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Alias { get; set; }
    }
}
