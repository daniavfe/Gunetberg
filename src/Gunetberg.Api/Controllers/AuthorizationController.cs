using Gunetberg.Api.Converter;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Port.Input;
using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "adsf";
        }

    }
}
