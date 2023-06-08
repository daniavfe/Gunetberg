using Gunetberg.Domain.Authorization;
using Gunetberg.Domain.User;

namespace Gunetberg.Port.Output.Repository
{
    public interface IAuthorizationRepository
    {
        AuthorizationUser GetAuthorizationUser(AuthorizationRequest authorizationRequest);
    }
}
