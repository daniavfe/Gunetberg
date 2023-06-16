using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.User;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controller
{
    [ApiController]
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
        public Task<Guid> CreateUser(CreateUserRequestDto createUserRequestDto)
        {
            return _userService.CreateUser(_userApiConverter.ToCreateUserRequest(createUserRequestDto));
        }

    }
}
