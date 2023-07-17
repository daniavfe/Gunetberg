using Gunetberg.Domain.Authorization;
using Gunetberg.Domain.Exception;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {

        private RepositoryContextFactory _repositoryContextfactory;

        public AuthorizationRepository(RepositoryContextFactory repositoryContextfactory)
        {
            _repositoryContextfactory = repositoryContextfactory;
        }

        public async Task<AuthorizationUser> GetAuthorizationUserAsync(HashedAuthorizationRequest authorizationRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Users
                .Where(x => x.Email == authorizationRequest.Email && x.Password == authorizationRequest.HashedPassword)
                .Select(x => new AuthorizationUser
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    Email = x.Email
                }).SingleOrDefaultAsync() ?? throw new EntityNotFoundException<AuthorizationUser>();

        }
    }
}
