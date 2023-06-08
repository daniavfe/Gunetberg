using Gunetberg.Domain.User;

namespace Gunetberg.Port.Output
{
    public interface ITokenClient
    {
        public string CreateToken(AuthorizationUser authorizationUser);
    }
}
