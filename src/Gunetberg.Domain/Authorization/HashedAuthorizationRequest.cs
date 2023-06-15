namespace Gunetberg.Domain.Authorization
{
    public class HashedAuthorizationRequest
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
