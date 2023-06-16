using FluentValidation;
using Gunetberg.Application.User.Validator;
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

        public Task<Guid> CreateUser(CreateUserRequest createUserRequest)
        {
            var validator = new CreateUserRequestValidator();
            validator.Validate(createUserRequest, options => options.ThrowOnFailures());

            return _userRepository.CreateUserAsync(createUserRequest);
        }

        public Task<SimpleUser> GetUser(Guid userId) {
            return _userRepository.GetUserAsync(userId);
        }

        public Task<bool> UpdateUser(UpdateUserRequest updateUserRequest)
        {
            return _userRepository.UpdateUserAsync(updateUserRequest);
        }
    }
}
