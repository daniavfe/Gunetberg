using Gunetberg.Domain.Exception;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository.Context;
using Gunetberg.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Repository
{
    public class UserRepository : IUserRepository
    {
        private RepositoryContextFactory _repositoryContextfactory;

        public UserRepository(RepositoryContextFactory repositoryContextfactory)
        {
            _repositoryContextfactory = repositoryContextfactory;
        }

        public async Task<Guid> CreateUserAsync(HashedCreateUserRequest hashedCreateUserRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();
            
            var user = new UserEntity
            {
                Alias = hashedCreateUserRequest.Alias,
                Password = hashedCreateUserRequest.Password,
                Email = hashedCreateUserRequest.Email,
                CreatedAt = DateTime.UtcNow
            };

            context.Users.Add(user);

            await context.SaveChangesAsync();

            return user.Id;
            
        }

        public async Task<SimpleUser> GetUserAsync(Guid id)
        {
            var context = _repositoryContextfactory.GetDBContext();
            
            return await context.Users
                .Select(x=>new SimpleUser
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    Email = x.Email,
                    Description = x.Description,
                    PhotoUrl = x.PhotoUrl
                })
                .SingleOrDefaultAsync(x => x.Id == id) ?? throw new EntityNotFoundException<SimpleUser>();  
        }

        public async Task UpdateUserAsync(UpdateUserRequest updateUserRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();
            
            var user =  await context.Users.SingleOrDefaultAsync(x => x.Id == updateUserRequest.Id) ?? throw new EntityNotFoundException<SimpleUser>();

            user.Description = updateUserRequest.Description;
            user.PhotoUrl = updateUserRequest?.PhotoUrl;

            context.Users.Update(user);

            await context.SaveChangesAsync();
        }
    }
}
