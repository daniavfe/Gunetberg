using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.User;
using Gunetberg.Client.Identity;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Api.Controller
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IdentityUtil _identityUtil;
        private readonly UserApiConverter _userApiConverter;

        public UserController(ILogger<UserController> logger, IUserService userService, IdentityUtil identityUtil, UserApiConverter userApiConverter)
        {
            _logger = logger;
            _userService = userService;
            _identityUtil = identityUtil;
            _userApiConverter = userApiConverter;
        }

        [HttpPost]
        [Route("/users")]
        [AllowAnonymous]
        public async Task<Guid> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            _logger.LogInformation($"Received create user request: {createUserRequestDto}");
            return await _userService.CreateUser(_userApiConverter.ToCreateUserRequest(createUserRequestDto));
        }

        [HttpGet]
        [Route("/users/me")]
        public async Task<UserDto> GetUser()
        {
            _logger.LogInformation($"Received get me request");
            return _userApiConverter.ToUserDto(await _userService.GetUser(_identityUtil.GetUserId()));
        }


        [HttpGet]
        [Route("/users/public/{userId}")]
        public async Task<PublicUserDto> GetPublicUser(Guid userId)
        {
            _logger.LogInformation($"Received get public user request: {userId}");
            return _userApiConverter.ToPublicUserDto(await _userService.GetPublicUser(userId));
        }


        [HttpPut]
        [Route("/users")]
        public async Task UpdateUser(UpdateUserRequestDto updateUserRequestDto)
        {
            _logger.LogInformation($"Received update user request: {updateUserRequestDto}");
            await _userService.UpdateUser(_userApiConverter.ToUpdateUserRequest(updateUserRequestDto, _identityUtil.GetUserId()));
        }

    }
}
