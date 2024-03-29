﻿using Gunetberg.Domain.User;

namespace Gunetberg.Port.Output.Repository
{
    public interface IUserRepository
    {
        Task<bool> IsAliasAlreadyInUse(string alias);
        public Task<Guid> CreateUserAsync(HashedCreateUserRequest hashedCreateUserRequest);
        public Task<CompletePublicUser> GetPublicUserByIdAsync(Guid userId);
        public Task<CompletePublicUser> GetPublicUserByAliasAsync(string alias);
        public Task<User> GetUserAsync(Guid id);
        Task<bool> IsEmailAlreadyInUse(string email);
        public Task UpdateUserDescriptionAsync(UpdateUserDescriptionRequest updateUserRequest);
        Task UpdateUserPhotoAsync(UpdateUserPhotoRequest updateUserPhotoRequest);
    }
}
