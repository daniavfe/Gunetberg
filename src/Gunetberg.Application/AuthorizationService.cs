using Gunetberg.Domain.Authorization;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Application
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

        public string GetAuthorizationToken(AuthorizationRequest authorizationRequest)
        {
            var user = _authorizationRepository.GetAuthorizationToken(authorizationRequest);
            return _tokenClient.CreateToken(user);
        }
    }
}
