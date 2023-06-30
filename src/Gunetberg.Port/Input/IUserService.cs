using Gunetberg.Domain.User;

namespace Gunetberg.Port.Input
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserRequest createUserRequest);
        Task<SimpleUser> GetUser(Guid id);
        Task UpdateUser(UpdateUserRequest updateUserRequest);
    }
}
