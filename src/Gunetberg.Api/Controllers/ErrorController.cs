using Microsoft.AspNetCore.Mvc;


namespace Gunetberg.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpPost]
        [Route("/error")]
        public string ErrorPost()
        {
            return "Error happened";
        }

        [HttpGet]
        [Route("/error")]
        public string ErrorGet()
        {
            return "Error happened";
        }
    }
}
