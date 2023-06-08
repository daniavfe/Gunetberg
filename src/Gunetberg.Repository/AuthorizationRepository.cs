using Gunetberg.Domain.Authorization;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;

namespace Gunetberg.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        public AuthorizationUser GetAuthorizationUser(AuthorizationRequest authorizationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
