using Microsoft.AspNetCore.Builder;
using Shopfloor.Core.Middlewares;

namespace Shopfloor.Core.Extensions.Services
{
    public static class ApplicationRegistration
    {
        public static void UseSharedMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
