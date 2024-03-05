using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.User;
using Gunetberg.Client.Identity;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(OperationId = "CreateUser")]
        public async Task<Guid> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            _logger.LogInformation($"Received create user request: {createUserRequestDto}");
            return await _userService.CreateUser(_userApiConverter.ToCreateUserRequest(createUserRequestDto));
        }

        [HttpPut]
        [Route("/users/description")]
        [SwaggerOperation(OperationId = "UpdateUserDescription")]
        public async Task UpdateUserDescription(UpdateUserDescriptionRequestDto updateUserDescriptionRequestDto)
        {
            _logger.LogInformation($"Received update user description request: {updateUserDescriptionRequestDto}");
            await _userService.UpdateUserDescription(_userApiConverter.ToUpdateUserDescriptionRequest(updateUserDescriptionRequestDto, _identityUtil.GetUserId()));
        }

        [HttpPut]
        [Route("/users/photo")]
        [SwaggerOperation(OperationId = "UpdateUserPhoto")]
        public async Task UpdateUserPhoto(UpdateUserPhotoRequestDto updateUserPhotoRequestDto)
        {
            _logger.LogInformation($"Received update user photo request: {updateUserPhotoRequestDto}");
            await _userService.UpdateUserPhoto(_userApiConverter.ToUpdateUserPhotoRequest(updateUserPhotoRequestDto, _identityUtil.GetUserId()));
        }

        [HttpGet]
        [Route("/users/me")]
        [SwaggerOperation(OperationId = "GetCurrentUser")]
        public async Task<UserDto> GetUser()
        {
            _logger.LogInformation($"Received get me request");
            return _userApiConverter.ToUserDto(await _userService.GetUser(_identityUtil.GetUserId()));
        }


        [HttpGet]
        [Route("/users/public/id/{userId}")]
        [SwaggerOperation(OperationId = "GetPublicUserById")]
        public async Task<CompletePublicUserDto> GetPublicUserById(Guid userId)
        {
            _logger.LogInformation($"Received get public user request: {userId}");
            return _userApiConverter.ToCompletePublicUserDto(await _userService.GetPublicUserById(userId));
        }

        [HttpGet]
        [Route("/users/public/alias/{alias}")]
        [SwaggerOperation(OperationId = "GetPublicUserByAlias")]
        public async Task<CompletePublicUserDto> GetPublicUserByAlias(string alias)
        {
            _logger.LogInformation($"Received get public user request: {alias}");
            return _userApiConverter.ToCompletePublicUserDto(await _userService.GetPublicUserByAlias(alias));
        }




    }
}
