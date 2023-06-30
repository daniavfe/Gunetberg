using Dapper;
using Gunetberg.Domain.Exception;
using Gunetberg.Domain.Post;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Configuration;

namespace Gunetberg.Repository
{
    public class UserRepository : IUserRepository
    {
        private IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
                _connectionFactory = connectionFactory;
        }

        public async Task<Guid> CreateUserAsync(HashedCreateUserRequest hashedCreateUserRequest)
        {
            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                var query = "INSERT INTO Users (Email, Alias, Password, CreatedAt) OUTPUT inserted.Id VALUES (@Email, @Alias, @Password, GETUTCDATE())";
                return await con.QuerySingleOrDefaultAsync<Guid?>(query, hashedCreateUserRequest)
                    ?? throw new EntityNotCreatedException();
            }
        }

        public async Task<SimpleUser> GetUserAsync(Guid id)
        {
            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                var query = "SELECT Id, Email, Alias, Description, PhotoUrl FROM USERS WHERE Id = @Id";
                return await con.QuerySingleOrDefaultAsync<SimpleUser>(query, new {Id = id})
                     ?? throw new EntityNotFoundException<SimpleUser>();
            }
        }

        public async Task UpdateUserAsync(UpdateUserRequest updateUserRequest)
        {
            using (var con = _connectionFactory.GetConnection())
            {
                con.Open();
                var query = "UPDATE Users SET Description = @Description, PhotoUrl = @PhotoUrl WHERE Id = @Id";
                var result = await con.ExecuteAsync(query, updateUserRequest) == 1;

                if (!result)
                {
                    throw new EntityNotUpdatedException();
                }
            }
        }
    }
}
