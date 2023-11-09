using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Gunetberg.Client.Identity
{
    public class IdentityUtil
    {

        private readonly IHttpContextAccessor _httpContextAccessor;


        public IdentityUtil(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var userClaim = _httpContextAccessor?
                .HttpContext?
                .User?
                .Claims
                .SingleOrDefault(x => x.Type == ClaimTypes.Actor) ?? throw new Exception("");


            return Guid.Parse(userClaim.Value);

        }


    }
}
