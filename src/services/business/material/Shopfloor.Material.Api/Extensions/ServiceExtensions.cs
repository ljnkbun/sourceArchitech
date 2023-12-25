﻿using MassTransit;
using Shopfloor.EventBus.Extensions;
using Shopfloor.EventBus.Models.Requests;
using System.Security.Authentication;
using Shopfloor.EventBus.Models.Requests.Divisions;

namespace Shopfloor.Material.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                #region AddRequestClient
                x.AddRequestClient<GetCategoryByIdRequest>();
                x.AddRequestClient<GetCategoriesRequest>();
                x.AddRequestClient<GetCurrenciesRequest>();
                x.AddRequestClient<GetCountriesRequest>();
                x.AddRequestClient<GetSizeOrWidthRangesRequest>();
                x.AddRequestClient<GetProductGroupsRequest>();
                x.AddRequestClient<GetSubCategoriesRequest>();
                x.AddRequestClient<GetColorDefinitionsRequest>();
                x.AddRequestClient<GetCropSeasonsRequest>();
                x.AddRequestClient<GetStructuresRequest>();
                x.AddRequestClient<GetUOMsRequest>();
                x.AddRequestClient<GetMaterialTypesRequest>();
                x.AddRequestClient<GetFabricContentsRequest>();
                x.AddRequestClient<GetCountsRequest>();
                x.AddRequestClient<GetCompanyCurrenciesRequest>();
                x.AddRequestClient<GetGroupNamesRequest>();
                x.AddRequestClient<GetAccountGroupsRequest>();
                x.AddRequestClient<GetSupplierTypesRequest>();
                x.AddRequestClient<GetDivisionsRequest>();
                x.AddRequestClient<GetCompanyCurrenciesRequest>();
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
                });
                #endregion
            });
            services.AddEventBusService();
        }
    }
}
