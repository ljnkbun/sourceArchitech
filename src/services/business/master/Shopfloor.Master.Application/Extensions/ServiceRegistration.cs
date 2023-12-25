using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Core.Behaviours;
using Shopfloor.Master.Application.Jobs;

namespace Shopfloor.Master.Application.Extensions
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
            services.AddHostedService<WfxMasterDataSyncJob>();
            services.AddHostedService<WfxArticleDataSyncJob>();
        }
    }
}
