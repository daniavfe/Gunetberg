using Gunetberg.Domain.Authorization;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly ITokenClient _tokenClient;

        public AuthorizationService(IAuthorizationRepository authorizationRepository, ITokenClient tokenClient)
        {
            _authorizationRepository = authorizationRepository;
            _tokenClient = tokenClient;
        }

        public async Task<string> GetAuthorizationTokenAsync(AuthorizationRequest authorizationRequest)
        {
            var user = await _authorizationRepository.GetAuthorizationUserAsync(authorizationRequest);
            return _tokenClient.CreateToken(user);
        }
    }
}
