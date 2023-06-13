using Dapper;
using Gunetberg.Domain.Authorization;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Configuration;

namespace Gunetberg.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {

        private IConnectionFactory _connectionFactory;

        public AuthorizationRepository(IConnectionFactory connectionfactory) { 
            _connectionFactory = connectionfactory;
        }

        public async AuthorizationUser GetAuthorizationUser(AuthorizationRequest authorizationRequest)
        {
            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                var query = "SELECT email, alias FROM Users WHERE email = @Email AND password = @Pass";
                var result = con.QuerySingleOrDefaultAsync<AuthorizationUser>(query, authorizationRequest);
            }

            return null;
        }
    }
}
