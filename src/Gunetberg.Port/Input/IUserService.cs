using Gunetberg.Domain.User;

namespace Gunetberg.Port.Input
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserRequest createUserRequest);
    }
}
