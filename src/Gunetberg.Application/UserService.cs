using FluentValidation;
using Gunetberg.Application.Validators;
using Gunetberg.Domain.Exception;
using Gunetberg.Domain.User;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Application
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IHashClient _hashClient;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository, IHashClient hashClient)
        {
            _logger = logger;
            _userRepository = userRepository;
            _hashClient = hashClient;
        }

        public async Task<Guid> CreateUser(CreateUserRequest createUserRequest)
        {
            _logger.LogInformation($"Creating new user ${createUserRequest.Email} ${createUserRequest.Alias}");

            var validator = new CreateUserRequestValidator();
            validator.Validate(createUserRequest, options => options.ThrowOnFailures());

            if (await _userRepository.IsEmailAlreadyInUse(createUserRequest.Email))
            {
                _logger.LogInformation($"Email {createUserRequest.Email} is already in use");
                throw new EmailAlreadyInUseException();
            }

            if (await _userRepository.IsAliasAlreadyInUse(createUserRequest.Alias))
            {
                _logger.LogInformation($"Alias {createUserRequest.Alias} is already in use");
                throw new AliasAlreadyInUseException();
            }

            var hashedCreateUserRequest = new HashedCreateUserRequest
            {
                Email = createUserRequest.Email,
                Alias = createUserRequest.Alias,
                Password = _hashClient.Hash(createUserRequest.Password)
            };

            _logger.LogInformation($"Hashed user password");

            return await _userRepository.CreateUserAsync(hashedCreateUserRequest);

        }

        public async Task UpdateUserDescription(UpdateUserDescriptionRequest updateUserDescriptionRequest)
        {
            _logger.LogInformation($"Updating user description {updateUserDescriptionRequest}");
            await _userRepository.UpdateUserDescriptionAsync(updateUserDescriptionRequest);
        }

        public async Task UpdateUserPhoto(UpdateUserPhotoRequest updateUserPhotoRequest)
        {
            _logger.LogInformation($"Updating user photo {updateUserPhotoRequest}");
            await _userRepository.UpdateUserPhotoAsync(updateUserPhotoRequest);
        }

        public async Task<CompletePublicUser> GetPublicUserById(Guid userId)
        {
            _logger.LogInformation($"Obtaining public user of {userId}");
            return await _userRepository.GetPublicUserByIdAsync(userId);
        }

        public async Task<CompletePublicUser> GetPublicUserByAlias(string alias)
        {
            _logger.LogInformation($"Obtaining public user of {alias}");
            return await _userRepository.GetPublicUserByAliasAsync(alias);
        }

        public async Task<User> GetUser(Guid userId)
        {
            _logger.LogInformation($"Obtaining user of {userId}");
            return await _userRepository.GetUserAsync(userId);
        }

        
    }
}
