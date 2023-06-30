using Gunetberg.Api.Dto.User;
using Gunetberg.Domain.User;
using System.ComponentModel.DataAnnotations;

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

        public UpdateUserRequest ToUpdateUserRequest(UpdateUserRequestDto updateUserRequestDto, Guid userId)
        {
            return new UpdateUserRequest
            {
                Id = userId,
                Description = updateUserRequestDto.Description,
                PhotoUrl = updateUserRequestDto.PhotoUrl
            };
        }

        public UserDto ToUserDto(SimpleUser user)
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
    }
}
