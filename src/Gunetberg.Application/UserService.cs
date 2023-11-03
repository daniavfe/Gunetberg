using FluentValidation;
using Gunetberg.Application.Validators;
using Gunetberg.Domain.User;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application
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

        public async Task<Guid> CreateUser(CreateUserRequest createUserRequest)
        {
            var validator = new CreateUserRequestValidator();
            validator.Validate(createUserRequest, options => options.ThrowOnFailures());

            var hashedCreateUserRequest = new HashedCreateUserRequest
            {
                Email = createUserRequest.Email,
                Alias = createUserRequest.Alias,
                Password = _hashClient.Hash(createUserRequest.Password)
            };

            return await _userRepository.CreateUserAsync(hashedCreateUserRequest);
        }

        public async Task<PublicUser> GetPublicUser(Guid userId)
        {
            return await _userRepository.GetPublicUserAsync(userId);
        }

        public async Task<User> GetUser(Guid userId)
        {
            return await _userRepository.GetUserAsync(userId);
        }

        public async Task UpdateUser(UpdateUserRequest updateUserRequest)
        {
            await _userRepository.UpdateUserAsync(updateUserRequest);
        }
    }
}
