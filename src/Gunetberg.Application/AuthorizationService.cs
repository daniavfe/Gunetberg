using FluentValidation;
using Gunetberg.Application.Validators;
using Gunetberg.Domain.Authorization;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Application
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ILogger<AuthorizationService> _logger;
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IHashClient _hashClient;
        private readonly ITokenClient _tokenClient;

        public AuthorizationService(
            ILogger<AuthorizationService> logger,
            IAuthorizationRepository authorizationRepository,
            IHashClient hashClient,
            ITokenClient tokenClient)
        {
            _logger = logger;
            _authorizationRepository = authorizationRepository;
            _hashClient = hashClient;
            _tokenClient = tokenClient;
        }

        public async Task<string> GetAuthorizationTokenAsync(AuthorizationRequest authorizationRequest)
        {
            _logger.LogInformation("Validating authorization request");
            var validator = new AuthorizationRequestValidator();
            validator.Validate(authorizationRequest, options => options.ThrowOnFailures());

            _logger.LogInformation("Hashing password");
            var hashedAuthorizationRequest = new HashedAuthorizationRequest
            {
                Email = authorizationRequest.Email,
                HashedPassword = _hashClient.Hash(authorizationRequest.Password)
            };

            _logger.LogInformation("Searching user in database");
            var user = await _authorizationRepository.GetAuthorizationUserAsync(hashedAuthorizationRequest);

            _logger.LogInformation($"Creating token with user:{user}");
            return _tokenClient.CreateToken(user);
        }
    }
}
