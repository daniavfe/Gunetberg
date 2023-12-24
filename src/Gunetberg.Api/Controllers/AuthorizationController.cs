using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(OperationId = "Auth")]
        public async Task<AuthorizationResponseDto> Auth(AuthorizationRequestDto authorizationRequest)
        {
            _logger.LogInformation($"Received authorization request: {authorizationRequest}");
            return _authorizationApiConverter.ToAuthorizationResponseDto(
                await _authorizationService.GetAuthorizationTokenAsync(_authorizationApiConverter.ToAuthorizationRequest(authorizationRequest))
            );
        }

    }
}
