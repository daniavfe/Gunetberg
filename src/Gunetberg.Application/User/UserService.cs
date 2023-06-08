using Gunetberg.Domain.User;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(CreateUserRequest createUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
