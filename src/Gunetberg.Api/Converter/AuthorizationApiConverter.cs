using Gunetberg.Api.Dto.Authorization;
using Gunetberg.Domain.Authorization;

namespace Gunetberg.Api.Converter
{
    public class AuthorizationApiConverter
    {
        public AuthorizationRequest ToAuthorizationRequest(AuthorizationRequestDto authorizationRequestDto)
        {
            return new AuthorizationRequest
            {
                Email = authorizationRequestDto.Email,
                Password = authorizationRequestDto.Password,
            };
        }

        public AuthorizationResponseDto ToAuthorizationResponseDto(string accessToken)
        {
            return new AuthorizationResponseDto
            {
                AccessToken = accessToken,
            };
        }
    }
}
