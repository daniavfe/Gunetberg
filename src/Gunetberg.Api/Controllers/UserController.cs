using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.User;
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
        private readonly UserApiConverter _userApiConverter;

        public UserController(IUserService userService, UserApiConverter userApiConverter)
        {
            _userService = userService;
            _userApiConverter = userApiConverter;
        }

        [HttpPost]
        [Route("/users")]
        [AllowAnonymous]
        public Task<Guid> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            return _userService.CreateUser(_userApiConverter.ToCreateUserRequest(createUserRequestDto));
        }


        [HttpPut]
        [Route("/users")]
        public Task UpdateUser(UpdateUserRequestDto updateUserRequestDto)
        {
            var x = HttpContext.User;
            return _userService.UpdateUser(_userApiConverter.ToUpdateUserRequest(updateUserRequestDto));
        }

    }
}
