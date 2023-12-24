using Gunetberg.Api.Dto.User;
using Gunetberg.Domain.User;

namespace Gunetberg.Api.Converter
{
    public class UserApiConverter
    {
        public CreateUserRequest ToCreateUserRequest(CreateUserRequestDto createUserRequestDto)
        {
            return new CreateUserRequest
            {
                Email = createUserRequestDto.Email.Trim(),
                Alias = createUserRequestDto.Alias.Trim(),
                Password = createUserRequestDto.Password.Trim(),
                PasswordCheck = createUserRequestDto.PasswordCheck.Trim()
            };
        }

        public UpdateUserDescriptionRequest ToUpdateUserDescriptionRequest(UpdateUserDescriptionRequestDto updateUserDescriptionRequestDto, Guid userId)
        {
            return new UpdateUserDescriptionRequest
            {
                Id = userId,
                Description = updateUserDescriptionRequestDto.Description
            };
        }

        public UpdateUserPhotoRequest ToUpdateUserPhotoRequest(UpdateUserPhotoRequestDto updateUserPhotoRequestDto, Guid userId)
        {
            return new UpdateUserPhotoRequest
            {
                Id = userId,
                PhotoUrl = updateUserPhotoRequestDto.PhotoUrl
            };
        }

        public UserDto ToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Alias = user.Alias,
                PhotoUrl = user.PhotoUrl,
                Description = user.Description
            };
        }

        public PublicUserDto ToPublicUserDto(PublicUser publicUser)
        {
            return new PublicUserDto
            {
                Id = publicUser.Id,
                Alias = publicUser.Alias,
                PhotoUrl = publicUser.PhotoUrl
            };
        }

        public CompletePublicUserDto ToCompletePublicUserDto(CompletePublicUser completePublicUser)
        {
            return new CompletePublicUserDto
            {
                Id = completePublicUser.Id,
                Alias = completePublicUser.Alias,
                PhotoUrl = completePublicUser.PhotoUrl,
                Description = completePublicUser.Description
            };
        }

        public AdminAuthorDto ToAdminAuthorDto(AdminAuthor author)
        {
            return new AdminAuthorDto
            {
                Id = author.Id,
                Alias = author.Alias,
                Email = author.Email
            };
        }
    }
}
