using Shopfloor.Core.Services;
using System.Security.Claims;

namespace Shopfloor.Consumption.Api.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            var uid = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
            if (!string.IsNullOrEmpty(uid)) UserId = new Guid(uid);
        }

        public Guid? UserId { get; }
    }
}
