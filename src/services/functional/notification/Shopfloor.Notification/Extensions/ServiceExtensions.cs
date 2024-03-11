using MassTransit;
using Shopfloor.EventBus.Definations;
using Shopfloor.EventBus.Extensions;
using Shopfloor.Notification.Consumers;
using System.Security.Authentication;

namespace Shopfloor.Notification.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                #region AddConsumer
                x.AddConsumer<ChatMessageConsumer>();

                x.AddConsumer<UpdateStatusImportsConsumer>();
                x.AddConsumer<UpdateStatusImportArticlesConsumer>();
                x.AddConsumer<UpdateStatusImportDetailsConsumer>();
                x.AddConsumer<UpdateStatusExportsConsumer>();
                x.AddConsumer<UpdateStatusExportArticlesConsumer>();
                x.AddConsumer<UpdateStatusExportDetailsConsumer>();
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

                    cfg.ReceiveEndpoint(MessageQueueName.ChatMessage, e =>
                    {
                        e.ConfigureConsumer<ChatMessageConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(MessageQueueName.UpdateStatusImportsMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateStatusImportsConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(MessageQueueName.UpdateStatusImportArticlesMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateStatusImportArticlesConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(MessageQueueName.UpdateStatusImportDetailsMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateStatusImportDetailsConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(MessageQueueName.UpdateStatusExportsMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateStatusExportsConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(MessageQueueName.UpdateStatusExportArticlesMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateStatusExportArticlesConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(MessageQueueName.UpdateStatusExportDetailsMessage, e =>
                    {
                        e.ConfigureConsumer<UpdateStatusExportDetailsConsumer>(context);
                    });
                });
                #endregion
            });
            services.AddEventBusService();
        }
    }
}
