using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Core.Behaviours;
using Shopfloor.Planning.Application.Jobs;
using System.Reflection;

namespace Shopfloor.Planning.Application.Extensions
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
        }
    
        public static void AddJob(this IServiceCollection services)
        {
            services.AddHostedService<SyncPorDataJob>();
        }
    }
}
