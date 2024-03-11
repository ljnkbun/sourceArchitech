using System.Security.Authentication;
using MassTransit;
using Shopfloor.Ambassador.Api.Consumers.Requests;
using Shopfloor.Ambassador.Api.Consumers.Wfxs;
using Shopfloor.EventBus.Definations;
using Shopfloor.EventBus.Extensions;
using Shopfloor.Master.Api.Consumers.Requests;

namespace Shopfloor.Ambassador.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                #region AddConsumer
                x.AddConsumer<GetWfxMasterDataRequestConsumer>();
                x.AddConsumer<GetWfxArticleRequestConsumer>();
                x.AddConsumer<GetWfxPOArticleRequestConsumer>();
                x.AddConsumer<GetWfxGDIRequestConsumer>();
                x.AddConsumer<GetWfxGDNRequestConsumer>();
                x.AddConsumer<GetWfxPorRequestConsumer>();
                x.AddConsumer<GetWfxWebSharedServiceConsumer>();
                x.AddConsumer<GetWFXOperationLibraryRequestConsumer>();
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

                    // Wfx
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxArticleRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxArticleRequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxMasterDataRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxMasterDataRequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxPOArticleRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxPOArticleRequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxGDIRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxGDIRequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxGDNRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxGDNRequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxPorRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxPorRequestConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWfxWebSharedRequest, e =>
                    {
                        e.ConfigureConsumer<GetWfxWebSharedServiceConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RequestQueueName.GetWFXOperationLibraryRequest, e =>
                    {
                        e.ConfigureConsumer<GetWFXOperationLibraryRequestConsumer>(context);
                    });
                });
                #endregion
            });
            services.AddEventBusService();
        }
    }
}
