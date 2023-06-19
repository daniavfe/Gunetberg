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

        public UpdateUserRequest ToUpdateUserRequest(UpdateUserRequestDto updateUserRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
