using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.User;
using Gunetberg.Client.Identity;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controller
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IdentityUtil _identityUtil;
        private readonly UserApiConverter _userApiConverter;

        public UserController(IUserService userService, IdentityUtil identityUtil)
        {
            _userService = userService;
            _identityUtil = identityUtil;
            _userApiConverter = new UserApiConverter();
        }

        [HttpPost]
        [Route("/users")]
        [AllowAnonymous]
        public Task<Guid> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            return _userService.CreateUser(_userApiConverter.ToCreateUserRequest(createUserRequestDto));
        }

        [HttpGet]
        [Route("/users/me")]
        public async Task<UserDto> GetUser()
        {
            return _userApiConverter.ToUserDto(await _userService.GetUser(_identityUtil.GetUserId()));
        }


        [HttpPut]
        [Route("/users")]
        public async Task UpdateUser(UpdateUserRequestDto updateUserRequestDto)
        {
             await _userService.UpdateUser(_userApiConverter.ToUpdateUserRequest(updateUserRequestDto, _identityUtil.GetUserId()));
        }

    }
}
