using Gunetberg.Domain.Authorization;

namespace Gunetberg.Port.Input
{
    public interface IAuthorizationService
    {
        public Task<string> GetAuthorizationTokenAsync(AuthorizationRequest authorizationRequest);
    }
}
