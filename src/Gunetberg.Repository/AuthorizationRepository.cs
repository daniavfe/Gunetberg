using Dapper;
using Gunetberg.Domain.Authorization;
using Gunetberg.Domain.Exception;
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

        public async Task<AuthorizationUser> GetAuthorizationUserAsync(HashedAuthorizationRequest authorizationRequest)
        {
            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                var query = "SELECT Id, Email, Alias FROM Users WHERE Email = @Email AND Password = @HashedPassword";
                return await con.QuerySingleOrDefaultAsync<AuthorizationUser>(query, authorizationRequest) 
                    ?? throw new EntityNotFoundException<AuthorizationUser>();
            }
        }
    }
}
