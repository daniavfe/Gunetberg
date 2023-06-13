using Gunetberg.Domain.User;
using Gunetberg.Port.Output;

namespace Gunetberg.Client.Token
{
    public class JwtTokenClient : ITokenClient
    {
        public string CreateToken(AuthorizationUser authorizationUser)
        {
            return "HELLO";
        }
    }
}
