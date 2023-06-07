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
