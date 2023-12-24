
namespace Gunetberg.Domain.User
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public string PasswordCheck { get; set; }

    }
}
