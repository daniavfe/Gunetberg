using Gunetberg.Domain.Authorization;

namespace Gunetberg.Port.Input
{
    public interface IAuthorizationService
    {
        public string GetAuthorizationToken(AuthorizationRequest authorizationRequest);
    }
}
