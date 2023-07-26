using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly Port.Input.IAuthorizationService _authorizationService;
        private readonly AuthorizationApiConverter _authorizationApiConverter;

        public AuthorizationController(Port.Input.IAuthorizationService authorizationService, AuthorizationApiConverter authorizationApiConverter)
        {
            _authorizationApiConverter = authorizationApiConverter;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("/auth")]
        [AllowAnonymous]
        public Task<string> Auth(AuthorizationRequestDto authorizationRequest)
        {
            return _authorizationService.GetAuthorizationTokenAsync(_authorizationApiConverter.ToAuthorizationRequest(authorizationRequest));
        }

        [HttpGet]
        [Route("/auth/validate")]
        public void Validate()
        {
            return;
        }

    }
}
