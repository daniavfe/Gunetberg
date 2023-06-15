using Gunetberg.Domain.Authorization;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IHashClient _hashClient;
        private readonly ITokenClient _tokenClient;

        public AuthorizationService(
            IAuthorizationRepository authorizationRepository, 
            IHashClient hashClient,
            ITokenClient tokenClient)
        {
            _authorizationRepository = authorizationRepository;
            _hashClient = hashClient;
            _tokenClient = tokenClient;
        }

        public async Task<string> GetAuthorizationTokenAsync(AuthorizationRequest authorizationRequest)
        {

            var hashedAuthorizationRequest = new HashedAuthorizationRequest
            {
                Email = authorizationRequest.Email,
                HashedPassword = _hashClient.Hash(authorizationRequest.Password)
            };

            var user = await _authorizationRepository.GetAuthorizationUserAsync(hashedAuthorizationRequest);
            return _tokenClient.CreateToken(user);
        } 
    }
}
