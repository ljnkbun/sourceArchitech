using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Core.Behaviours;
using System.Reflection;

namespace Shopfloor.Ambassador.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AmbassadorBehavior<,>));
        }
    }
}
