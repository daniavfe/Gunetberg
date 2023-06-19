using FluentValidation;
using Gunetberg.Application.User.Validator;
using Gunetberg.Domain.User;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashClient _hashClient;

        public UserService(IUserRepository userRepository, IHashClient hashClient)
        {
            _userRepository = userRepository;
            _hashClient = hashClient;
        }

        public Task<Guid> CreateUser(CreateUserRequest createUserRequest)
        {
            var validator = new CreateUserRequestValidator();
            validator.Validate(createUserRequest, options => options.ThrowOnFailures());

            var hashedCreateUserRequest = new HashedCreateUserRequest
            {
                Email = createUserRequest.Email,
                Alias = createUserRequest.Alias,
                Password = _hashClient.Hash(createUserRequest.Password)
            };

            return _userRepository.CreateUserAsync(hashedCreateUserRequest);
        }

        public Task<SimpleUser> GetUser(Guid userId) {
            return _userRepository.GetUserAsync(userId);
        }

        public Task UpdateUser(UpdateUserRequest updateUserRequest)
        {
            return _userRepository.UpdateUserAsync(updateUserRequest);
        }
    }
}
