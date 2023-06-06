using Microsoft.AspNetCore.Mvc;

namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {

        [HttpGet]
        public string Hello()
        {
            return "hello";
        }
    }
}
