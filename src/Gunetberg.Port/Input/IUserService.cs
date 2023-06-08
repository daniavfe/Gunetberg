using Gunetberg.Domain.User;

namespace Gunetberg.Port.Input
{
    public interface IUserService
    {
        void CreateUser(CreateUserRequest createUserRequest);
    }
}
