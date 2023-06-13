using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Authorization;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly AuthorizationApiConverter _authorizationApiConverter;

        public AuthorizationController(IAuthorizationService authorizationService, AuthorizationApiConverter authorizationApiConverter)
        {
            _authorizationApiConverter = authorizationApiConverter;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("/auth")]
        public Task<string> Auth(AuthorizationRequestDto authorizationRequest)
        {
            return _authorizationService.GetAuthorizationTokenAsync(_authorizationApiConverter.ToAuthorizationRequest(authorizationRequest));
        }

    }
}
