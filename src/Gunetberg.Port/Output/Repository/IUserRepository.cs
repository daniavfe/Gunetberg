using Gunetberg.Domain.User;

namespace Gunetberg.Port.Output.Repository
{
    public interface IUserRepository
    {
        public Task<Guid> CreateUserAsync(HashedCreateUserRequest hashedCreateUserRequest);
        public Task<PublicUser> GetPublicUserAsync(Guid userId);
        public Task<User> GetUserAsync(Guid id);

        public Task UpdateUserAsync(UpdateUserRequest updateUserRequest);
    }
}
