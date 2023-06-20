using Gunetberg.Domain.User;

namespace Gunetberg.Port.Output.Repository
{
    public interface IUserRepository
    {
        public Task<Guid> CreateUserAsync(HashedCreateUserRequest hashedCreateUserRequest);

        public Task<SimpleUser> GetUserAsync(Guid id);

        public Task UpdateUserAsync(UpdateUserRequest updateUserRequest);
    }
}
