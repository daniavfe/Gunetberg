using Gunetberg.Domain.User;

namespace Gunetberg.Port.Input
{
    public interface IUserService
    {
        Task<Guid> CreateUser(CreateUserRequest createUserRequest);
        Task<CompletePublicUser> GetPublicUserById(Guid userId);
        Task<CompletePublicUser> GetPublicUserByAlias(string alias);
        Task<User> GetUser(Guid id);
        Task UpdateUserDescription(UpdateUserDescriptionRequest updateUserDescriptionRequest);
        Task UpdateUserPhoto(UpdateUserPhotoRequest updateUserPhotoRequest);
    }
}
