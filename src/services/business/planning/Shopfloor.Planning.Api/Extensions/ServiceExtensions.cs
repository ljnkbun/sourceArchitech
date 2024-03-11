using MassTransit;
using Shopfloor.EventBus.Definations;
using Shopfloor.EventBus.Extensions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Requests.Masters.Factories;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.Master.Api.Consumers.Requests;
using Shopfloor.Planning.Api.Consumers;
using Shopfloor.Planning.Api.Consumers.Messages;
using System.Security.Authentication;

namespace Shopfloor.Planning.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                #region AddRequestClient

                // Machine
                x.AddRequestClient<GetMachineByIdRequest>();
                x.AddRequestClient<GetMachinesRequest>();

                // Line
                x.AddRequestClient<GetLineByIdRequest>();
                x.AddRequestClient<GetLinesRequest>();

                //Category
                x.AddRequestClient<GetCategoryByIdRequest>();
                x.AddRequestClient<GetCategoriesRequest>();

                //ProductGroup
                x.AddRequestClient<GetProductGroupByIdRequest>();
                x.AddRequestClient<GetProductGroupsRequest>();

                //Calendar
                x.AddRequestClient<GetCalendarByIdRequest>();
                x.AddRequestClient<GetCalendarByIdsRequest>();

                //PlanningGroupFactory
                x.AddRequestClient<GetPlanningGroupByIdRequest>();
                x.AddRequestClient<GetPlanningGroupFactoryByIdsRequest>();

                //Holiday
                x.AddRequestClient<GetHolidayByIdRequest>();
                x.AddRequestClient<GetHolidaysRequest>();

                //POR
                x.AddRequestClient<GetWfxPorRequest>();

                // Factory
                x.AddRequestClient<GetFactoriesRequest>();
                x.AddRequestClient<GetFactoryByIdRequest>();

                #endregion

                x.AddConsumer<GetFPPOByIdRequestConsumer>();
                x.AddConsumer<GetFPPOsRequestConsumer>();

                #region AddConsumer

                x.AddConsumer<UpdateActualQuanlityForStripConsumer>();
                x.AddConsumer<CalculateFactoryCapacityMessageConsumer>();

                #endregion

                #region UsingRabbitMq

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.PrefetchCount = 50;
                    cfg.AutoDelete = true;
                    cfg.Durable = true;

                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                    {
                        var host = new Uri(configuration["RabbitMQSettings:Uri"]);
                        _ = bool.TryParse(configuration["RabbitMQSettings:SSL"], out bool ssl);
                        cfg.Host(host, h =>
                        {
                            h.Username(configuration["RabbitMQSettings:Username"]);
                            h.Password(configuration["RabbitMQSettings:Password"]);
                            if (ssl)
                            {
                                h.UseSsl(s =>
                                {
                                    s.Protocol = SslProtocols.Tls12;
                                });
                            }
                        });
                    }
                    else
                    {
                        var host = Environment.GetEnvironmentVariable("RabbitMQ_Host");
                        _ = ushort.TryParse(Environment.GetEnvironmentVariable("RabbitMQ_Port"), out ushort port);
                        _ = bool.TryParse(Environment.GetEnvironmentVariable("RabbitMQ_SSL"), out bool ssl);
                        var username = Environment.GetEnvironmentVariable("RabbitMQ_Username");
                        var password = Environment.GetEnvironmentVariable("RabbitMQ_Password");
                        cfg.Host(host, port, "/", h =>
                        {
                            h.Username(username);
                            h.Password(password);
                            if (ssl)
                            {
                                h.UseSsl(s =>
                                {
                                    s.Protocol = SslProtocols.Tls12;
                                });
                            }
                        });
                    }

                    cfg.ReceiveEndpoint(RequestQueueName.GetFPPOByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetFPPOByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetFPPOsRequest, e =>
                    {
                        e.ConfigureConsumer<GetFPPOsRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(MessageQueueName.UpdateActualQuanlityForStripMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateActualQuanlityForStripConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(MessageQueueName.CalculateFactoryCapacityMessage, e =>
                    {
                        e.ConfigureConsumer<CalculateFactoryCapacityMessageConsumer>(context);
                    });
                });
                #endregion
            });
            services.AddEventBusService();
        }
    }
}
