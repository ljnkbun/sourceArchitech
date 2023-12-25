using Microsoft.Extensions.DependencyInjection;
using Shopfloor.EventBus.Services;

namespace Shopfloor.EventBus.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddEventBusService(this IServiceCollection services)
        {
            services.AddTransient<IRequestClientService, RequestClientService>();
        }
    }
}
