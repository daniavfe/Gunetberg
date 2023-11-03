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

        public UpdateUserRequest ToUpdateUserRequest(UpdateUserRequestDto updateUserRequestDto, Guid userId)
        {
            return new UpdateUserRequest
            {
                Id = userId,
                Description = updateUserRequestDto.Description,
                PhotoUrl = updateUserRequestDto.PhotoUrl
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

        public PublicUserDto ToPublicUserDto(PublicUser user)
        {
            return new PublicUserDto
            {
                Id = user.Id,
                Alias = user.Alias,
                PhotoUrl = user.PhotoUrl
            };
        }

        public AuthorDto ToAuthorDto(Author author) {
            return new AuthorDto
            {
                Id = author.Id,
                Alias = author.Alias,
                PhotoUrl = author.PhotoUrl,
                Description = author.Description
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
