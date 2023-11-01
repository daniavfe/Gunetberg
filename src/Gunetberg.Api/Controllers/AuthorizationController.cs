using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gunetberg.Api.Controller
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly Port.Input.IAuthorizationService _authorizationService;
        private readonly AuthorizationApiConverter _authorizationApiConverter;

        public AuthorizationController(ILogger<AuthorizationController> logger, Port.Input.IAuthorizationService authorizationService, AuthorizationApiConverter authorizationApiConverter)
        {
            _logger = logger;
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
            _logger.LogInformation("Validate endpoint reached and updated");
        }

    }
}
