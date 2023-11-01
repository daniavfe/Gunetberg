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

        public UserController(IUserService userService, IdentityUtil identityUtil, UserApiConverter userApiConverter)
        {
            _userService = userService;
            _identityUtil = identityUtil;
            _userApiConverter = userApiConverter;
        }

        [HttpPost]
        [Route("/users")]
        [AllowAnonymous]
        public async Task<Guid> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            return await _userService.CreateUser(_userApiConverter.ToCreateUserRequest(createUserRequestDto));
        }

        [HttpGet]
        [Route("/users/me")]
        public async Task<UserDto> GetUser()
        {
            return _userApiConverter.ToUserDto(await _userService.GetUser(_identityUtil.GetUserId()));
        }

        [HttpGet]
        [Route("/users/public")]
        public async Task<PublicUserDto> GetPublicUser()
        {
            return _userApiConverter.ToPublicUserDto(await _userService.GetUser(_identityUtil.GetUserId()));
        }

        [HttpGet]
        [Route("/users/public/{userId}")]
        public async Task<PublicUserDto> GetPublicUser(Guid userId)
        {
            return _userApiConverter.ToPublicUserDto(await _userService.GetUser(userId));
        }


        [HttpPut]
        [Route("/users")]
        public async Task UpdateUser(UpdateUserRequestDto updateUserRequestDto)
        {
            await _userService.UpdateUser(_userApiConverter.ToUpdateUserRequest(updateUserRequestDto, _identityUtil.GetUserId()));
        }

    }
}
