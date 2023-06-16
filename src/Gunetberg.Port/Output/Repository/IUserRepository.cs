using Gunetberg.Domain.User;

namespace Gunetberg.Port.Output.Repository
{
    public interface IUserRepository
    {
        public Task<Guid> CreateUserAsync(CreateUserRequest createUserRequest);

        public Task<SimpleUser> GetUserAsync(Guid id);

        public Task<bool> UpdateUserAsync(UpdateUserRequest updateUserRequest);
    }
}
