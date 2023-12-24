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

        public async Task<bool> IsEmailAlreadyInUse(string email)
        {
            var context = _repositoryContextfactory.GetDBContext();
            return await context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> IsAliasAlreadyInUse(string alias)
        {
            var context = _repositoryContextfactory.GetDBContext();
            return await context.Users.AnyAsync(x => x.Alias == alias);
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

        public async Task<CompletePublicUser> GetPublicUserAsync(Guid id)
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Users
                .Select(x => new CompletePublicUser
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    PhotoUrl = x.PhotoUrl
                })
                .SingleOrDefaultAsync(x => x.Id == id) ?? throw new EntityNotFoundException<CompletePublicUser>();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var context = _repositoryContextfactory.GetDBContext();

            return await context.Users
                .Select(x => new User
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    Email = x.Email,
                    Description = x.Description,
                    PhotoUrl = x.PhotoUrl
                })
                .SingleOrDefaultAsync(x => x.Id == id) ?? throw new EntityNotFoundException<User>();
        }

        public async Task UpdateUserDescriptionAsync(UpdateUserDescriptionRequest updateUserRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var user = await context.Users.SingleOrDefaultAsync(x => x.Id == updateUserRequest.Id) ?? throw new EntityNotFoundException<User>();

            user.Description = updateUserRequest.Description;
            context.Users.Update(user);

            await context.SaveChangesAsync();
        }


        public async Task UpdateUserPhotoAsync(UpdateUserPhotoRequest updateUserRequest)
        {
            var context = _repositoryContextfactory.GetDBContext();

            var user = await context.Users.SingleOrDefaultAsync(x => x.Id == updateUserRequest.Id) ?? throw new EntityNotFoundException<User>();

            user.PhotoUrl = updateUserRequest.PhotoUrl;
            context.Users.Update(user);

            await context.SaveChangesAsync();
        }
    }
}
