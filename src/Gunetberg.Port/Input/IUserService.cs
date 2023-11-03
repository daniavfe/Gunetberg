using Gunetberg.Domain.User;

namespace Gunetberg.Port.Input
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserRequest createUserRequest);
        Task<PublicUser> GetPublicUser(Guid userId);
        Task<User> GetUser(Guid id);
        Task UpdateUser(UpdateUserRequest updateUserRequest);
    }
}
