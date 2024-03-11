using System.Security.Authentication;
using MassTransit;
using Shopfloor.EventBus.Definations;
using Shopfloor.EventBus.Extensions;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.Master.Api.Consumers.Requests;
using Shopfloor.Master.Api.Consumers.Requests.Buyers;
using Shopfloor.Master.Api.Consumers.Requests.Calendars;
using Shopfloor.Master.Api.Consumers.Requests.Divisions;
using Shopfloor.Master.Api.Consumers.Requests.Factories;
using Shopfloor.Master.Api.Consumers.Requests.Lines;
using Shopfloor.Master.Api.Consumers.Requests.Machines;
using Shopfloor.Master.Api.Consumers.Requests.PlanningGroups;
using Shopfloor.Master.Api.Consumers.Requests.Suppliers;

namespace Shopfloor.Master.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                #region AddRequestClient

                x.AddRequestClient<GetWfxArticleRequest>();
                x.AddRequestClient<GetWfxMasterDataRequest>();
                x.AddRequestClient<CalculateFactoryCapacityMessage>();
                x.AddRequestClient<GetWfxWebSharedRequest>();
                x.AddRequestClient<GetWFXOperationLibraryRequest>();
                #endregion

                #region AddConsumer
                //Supplier
                x.AddConsumer<GetSupplierByIdRequestConsumer>();
                x.AddConsumer<GetSuppliersRequestConsumer>();

                //Buyer
                x.AddConsumer<GetBuyerByIdRequestConsumer>();
                x.AddConsumer<GetBuyersRequestConsumer>();

                //Category
                x.AddConsumer<GetCategoryByIdRequestConsumer>();
                x.AddConsumer<GetCategoriesRequestConsumer>();

                // PricePer
                x.AddConsumer<GetPricePerByIdRequestConsumer>();
                x.AddConsumer<GetPricePersRequestConsumer>();

                // ColorDefinition
                x.AddConsumer<GetColorDefinitionByIdRequestConsumer>();
                x.AddConsumer<GetColorDefinitionsRequestConsumer>();

                // Color Card
                x.AddConsumer<GetColorCardByIdRequestConsumer>();
                x.AddConsumer<GetColorCardsRequestConsumer>();

                //SizeOrWidthRange
                x.AddConsumer<GetSizeOrWidthRangeByIdRequestConsumer>();
                x.AddConsumer<GetSizeOrWidthRangesRequestConsumer>();

                //CompanyCurrencies
                x.AddConsumer<GetCompanyCurrencyByIdRequestConsumer>();
                x.AddConsumer<GetCompanyCurrenciesRequestConsumer>();

                //Currencies
                x.AddConsumer<GetCurrencyByIdRequestConsumer>();
                x.AddConsumer<GetCurrenciesRequestConsumer>();

                //Themes
                x.AddConsumer<GetThemeByIdRequestConsumer>();
                x.AddConsumer<GetThemesRequestConsumer>();

                //FabricContents
                x.AddConsumer<GetFabricContentByIdRequestConsumer>();
                x.AddConsumer<GetFabricContentsRequestConsumer>();

                //Structures
                x.AddConsumer<GetStructureByIdRequestConsumer>();
                x.AddConsumer<GetStructuresRequestConsumer>();

                //SpinningMethod
                x.AddConsumer<GetSpinningMethodByIdRequestConsumer>();
                x.AddConsumer<GetSpinningMethodsRequestConsumer>();

                //Cetificate
                x.AddConsumer<GetCetificateByIdRequestConsumer>();
                x.AddConsumer<GetCetificatesRequestConsumer>();

                //Grade
                x.AddConsumer<GetGradeByIdRequestConsumer>();
                x.AddConsumer<GetGradesRequestConsumer>();

                //Construction
                x.AddConsumer<GetConstructionByIdRequestConsumer>();
                x.AddConsumer<GetConstructionsRequestConsumer>();

                //Count
                x.AddConsumer<GetCountByIdRequestConsumer>();
                x.AddConsumer<GetCountsRequestConsumer>();

                //CountTypes
                x.AddConsumer<GetCountTypeByIdRequestConsumer>();
                x.AddConsumer<GetCountTypesRequestConsumer>();

                //micronaires
                x.AddConsumer<GetMicronaireByIdRequestConsumer>();
                x.AddConsumer<GetMicronairesRequestConsumer>();

                //strengths
                x.AddConsumer<GetStrengthByIdRequestConsumer>();
                x.AddConsumer<GetStrengthsRequestConsumer>();

                //twists
                x.AddConsumer<GetTwistByIdRequestConsumer>();
                x.AddConsumer<GetTwistsRequestConsumer>();

                //FiberType
                x.AddConsumer<GetFiberTypeByIdRequestConsumer>();
                x.AddConsumer<GetFiberTypesRequestConsumer>();

                //FabricWidths
                x.AddConsumer<GetFabricWidthByIdRequestConsumer>();
                x.AddConsumer<GetFabricWidthsRequestConsumer>();

                //compositions
                x.AddConsumer<GetYarnCompositionByIdRequestConsumer>();
                x.AddConsumer<GetYarnCompositionsRequestConsumer>();

                //Staples
                x.AddConsumer<GetStapleByIdRequestConsumer>();
                x.AddConsumer<GetStaplesRequestConsumer>();

                //CropSeasons
                x.AddConsumer<GetCropSeasonByIdRequestConsumer>();
                x.AddConsumer<GetCropSeasonsRequestConsumer>();

                //Origins
                x.AddConsumer<GetOriginByIdRequestConsumer>();
                x.AddConsumer<GetOriginsRequestConsumer>();

                //spinningProcesses
                x.AddConsumer<GetSpinningProcessByIdRequestConsumer>();
                x.AddConsumer<GetSpinningProcessesRequestConsumer>();

                //SupplierTypes
                x.AddConsumer<GetSupplierTypeByIdRequestConsumer>();
                x.AddConsumer<GetSupplierTypesRequestConsumer>();

                //paymentTerms
                x.AddConsumer<GetPaymentTermByIdRequestConsumer>();
                x.AddConsumer<GetPaymentTermsRequestConsumer>();

                //deliveryTerms
                x.AddConsumer<GetDeliveryTermByIdRequestConsumer>();
                x.AddConsumer<GetDeliveryTermsRequestConsumer>();

                //Country
                x.AddConsumer<GetCountryByIdRequestConsumer>();
                x.AddConsumer<GetCountriesRequestConsumer>();

                //BuyerTypes
                x.AddConsumer<GetBuyerTypeByIdRequestConsumer>();
                x.AddConsumer<GetBuyerTypesRequestConsumer>();

                //Genders
                x.AddConsumer<GetGenderByIdRequestConsumer>();
                x.AddConsumer<GetGendersRequestConsumer>();

                //ProductGroup
                x.AddConsumer<GetProductGroupByIdRequestConsumer>();
                x.AddConsumer<GetProductGroupsRequestConsumer>();

                //MaterialType
                x.AddConsumer<GetMaterialTypeByIdRequestConsumer>();
                x.AddConsumer<GetMaterialTypesRequestConsumer>();

                //UOMConversions
                x.AddConsumer<GetUOMConversionByIdRequestConsumer>();
                x.AddConsumer<GetUOMConversionsRequestConsumer>();

                //shipmentTerms
                x.AddConsumer<GetShipmentTermByIdRequestConsumer>();
                x.AddConsumer<GetShipmentTermsRequestConsumer>();

                //Port
                x.AddConsumer<GetPortByIdRequestConsumer>();
                x.AddConsumer<GetPortsRequestConsumer>();

                //UOMs
                x.AddConsumer<GetUOMByIdRequestConsumer>();
                x.AddConsumer<GetUOMsRequestConsumer>();

                //Patterns
                x.AddConsumer<GetPatternByIdRequestConsumer>();
                x.AddConsumer<GetPatternsRequestConsumer>();

                //Department
                x.AddConsumer<GetDepartmentByIdRequestConsumer>();
                x.AddConsumer<GetDepartmentsRequestConsumer>();

                //SubCategory
                x.AddConsumer<GetSubCategoryByIdRequestConsumer>();
                x.AddConsumer<GetSubCategoriesRequestConsumer>();

                //AccountGroup
                x.AddConsumer<GetAccountGroupByIdRequestConsumer>();
                x.AddConsumer<GetAccountGroupsRequestConsumer>();

                //GroupName
                x.AddConsumer<GetGroupNameByIdRequestConsumer>();
                x.AddConsumer<GetGroupNamesRequestConsumer>();

                //Gauge
                x.AddConsumer<GetGaugeByIdRequestConsumer>();
                x.AddConsumer<GetGaugesRequestConsumer>();

                //MachineType
                x.AddConsumer<GetMachineTypeByIdRequestConsumer>();
                x.AddConsumer<GetMachineTypesRequestConsumer>();

                //Article
                x.AddConsumer<GetArticleByIdRequestConsumer>();
                x.AddConsumer<GetArticlesByIdsRequestConsumer>();
                x.AddConsumer<GetArticlessRequestConsumer>();
                x.AddConsumer<GetArticlesRequestConsumer>();

                //Process
                x.AddConsumer<GetProcessByIdRequestConsumer>();
                x.AddConsumer<GetProcessesRequestConsumer>();

                //OperationLibrary
                x.AddConsumer<GetOperationLibraryByIdRequestConsumer>();
                x.AddConsumer<GetOperationLibrariesRequestConsumer>();

                //SubOperationLibrary
                x.AddConsumer<GetSubOperationLibraryByIdRequestConsumer>();
                x.AddConsumer<GetSubOperationLibrariesRequestConsumer>();

                //Division
                x.AddConsumer<GetDivisionByIdRequestConsumer>();
                x.AddConsumer<GetDivisionsRequestConsumer>();

                // Holiday
                x.AddConsumer<GetHolidayByIdRequestConsumer>();
                x.AddConsumer<GetHolidaysRequestConsumer>();

                // Machine
                x.AddConsumer<GetMachineByIdRequestConsumer>();
                x.AddConsumer<GetMachinesRequestConsumer>();

                // Line
                x.AddConsumer<GetLineByIdRequestConsumer>();
                x.AddConsumer<GetLinesRequestConsumer>();


                // PlanningGroup
                x.AddConsumer<GetPlanningGroupByIdRequestConsumer>();
                x.AddConsumer<GetPlanningGroupsRequestConsumer>();

                // PlanningGroupFactory
                x.AddConsumer<GetPlanningGroupFactoryByIdRequestConsumer>();
                x.AddConsumer<GetPlanningGroupFactoryByIdsRequestConsumer>();
                x.AddConsumer<GetPlanningGroupFactoriesRequestConsumer>();

                // Calendar
                x.AddConsumer<GetCalendarByIdRequestConsumer>();
                x.AddConsumer<GetCalendarByIdsRequestConsumer>();
                x.AddConsumer<GetCalendarsRequestConsumer>();

                // Factory
                x.AddConsumer<GetFactoriesRequestConsumer>();
                x.AddConsumer<GetFactoryByIdRequestConsumer>();

                // DataCalculate
                x.AddConsumer<GetDataCalculateRequestConsumer>();

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
                    //Buyers
                    cfg.ReceiveEndpoint(RequestQueueName.GetBuyerByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetBuyerByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetBuyersRequest, e =>
                    {
                        e.ConfigureConsumer<GetBuyersRequestConsumer>(context);
                    });

                    //Suppliers
                    cfg.ReceiveEndpoint(RequestQueueName.GetSupplierByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSupplierByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSuppliersRequest, e =>
                    {
                        e.ConfigureConsumer<GetSuppliersRequestConsumer>(context);
                    });

                    //Categories
                    cfg.ReceiveEndpoint(RequestQueueName.GetCategoryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCategoryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCategoriesRequest, e =>
                    {
                        e.ConfigureConsumer<GetCategoriesRequestConsumer>(context);
                    });

                    //PricePer
                    cfg.ReceiveEndpoint(RequestQueueName.GetPricePerByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetPricePerByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPricePersRequest, e =>
                    {
                        e.ConfigureConsumer<GetPricePersRequestConsumer>(context);
                    });

                    //Color Definition
                    cfg.ReceiveEndpoint(RequestQueueName.GetColorDefinitionByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetColorDefinitionByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetColorDefinitionsRequest, e =>
                    {
                        e.ConfigureConsumer<GetColorDefinitionsRequestConsumer>(context);
                    });

                    //Color Card
                    cfg.ReceiveEndpoint(RequestQueueName.GetColorCardByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetColorCardByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetColorCardsRequest, e =>
                    {
                        e.ConfigureConsumer<GetColorCardsRequestConsumer>(context);
                    });

                    //SizeOrWidthRange
                    cfg.ReceiveEndpoint(RequestQueueName.GetSizeOrWidthRangeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSizeOrWidthRangeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSizeOrWidthRangesRequest, e =>
                    {
                        e.ConfigureConsumer<GetSizeOrWidthRangesRequestConsumer>(context);
                    });

                    //CompanyCurrencies
                    cfg.ReceiveEndpoint(RequestQueueName.GetCompanyCurrencyByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCompanyCurrencyByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCompanyCurrenciesRequest, e =>
                    {
                        e.ConfigureConsumer<GetCompanyCurrenciesRequestConsumer>(context);
                    });

                    //Currencies
                    cfg.ReceiveEndpoint(RequestQueueName.GetCurrencyByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCurrencyByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCurrenciesRequest, e =>
                    {
                        e.ConfigureConsumer<GetCurrenciesRequestConsumer>(context);
                    });

                    //Themes
                    cfg.ReceiveEndpoint(RequestQueueName.GetThemeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetThemeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetThemesRequest, e =>
                    {
                        e.ConfigureConsumer<GetThemesRequestConsumer>(context);
                    });

                    //FabricContents
                    cfg.ReceiveEndpoint(RequestQueueName.GetFabricContentByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetFabricContentByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetFabricContentsRequest, e =>
                    {
                        e.ConfigureConsumer<GetFabricContentsRequestConsumer>(context);
                    });

                    //Structures
                    cfg.ReceiveEndpoint(RequestQueueName.GetStructureByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetStructureByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetStructuresRequest, e =>
                    {
                        e.ConfigureConsumer<GetStructuresRequestConsumer>(context);
                    });

                    //SpinningMethod
                    cfg.ReceiveEndpoint(RequestQueueName.GetSpinningMethodByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSpinningMethodByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSpinningMethodsRequest, e =>
                    {
                        e.ConfigureConsumer<GetSpinningMethodsRequestConsumer>(context);
                    });

                    //Cetificate
                    cfg.ReceiveEndpoint(RequestQueueName.GetCetificateByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCetificateByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCetificatesRequest, e =>
                    {
                        e.ConfigureConsumer<GetCetificatesRequestConsumer>(context);
                    });

                    //Grades
                    cfg.ReceiveEndpoint(RequestQueueName.GetGradeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetGradeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetGradesRequest, e =>
                    {
                        e.ConfigureConsumer<GetGradesRequestConsumer>(context);
                    });

                    //Construction
                    cfg.ReceiveEndpoint(RequestQueueName.GetConstructionByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetConstructionByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetConstructionsRequest, e =>
                    {
                        e.ConfigureConsumer<GetConstructionsRequestConsumer>(context);
                    });

                    //Count
                    cfg.ReceiveEndpoint(RequestQueueName.GetCountByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCountByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCountsRequest, e =>
                    {
                        e.ConfigureConsumer<GetCountsRequestConsumer>(context);
                    });

                    //CountTypes
                    cfg.ReceiveEndpoint(RequestQueueName.GetCountTypeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCountTypeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCountTypesRequest, e =>
                    {
                        e.ConfigureConsumer<GetCountTypesRequestConsumer>(context);
                    });

                    //Micronaire
                    cfg.ReceiveEndpoint(RequestQueueName.GetMicronaireByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetMicronaireByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetMicronairesRequest, e =>
                    {
                        e.ConfigureConsumer<GetMicronairesRequestConsumer>(context);
                    });

                    //Strengths
                    cfg.ReceiveEndpoint(RequestQueueName.GetStrengthByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetStrengthByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetStrengthsRequest, e =>
                    {
                        e.ConfigureConsumer<GetStrengthsRequestConsumer>(context);
                    });

                    //Twist
                    cfg.ReceiveEndpoint(RequestQueueName.GetTwistByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetTwistByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetTwistsRequest, e =>
                    {
                        e.ConfigureConsumer<GetTwistsRequestConsumer>(context);
                    });

                    //FiberType
                    cfg.ReceiveEndpoint(RequestQueueName.GetFiberTypeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetFiberTypeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetFiberTypesRequest, e =>
                    {
                        e.ConfigureConsumer<GetFiberTypesRequestConsumer>(context);
                    });


                    //FabricWidth
                    cfg.ReceiveEndpoint(RequestQueueName.GetFabricWidthByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetFabricWidthByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetFabricWidthsRequest, e =>
                    {
                        e.ConfigureConsumer<GetFabricWidthsRequestConsumer>(context);
                    });

                    //Compositions
                    cfg.ReceiveEndpoint(RequestQueueName.GetYarnCompositionByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetYarnCompositionByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetYarnCompositionsRequest, e =>
                    {
                        e.ConfigureConsumer<GetYarnCompositionsRequestConsumer>(context);
                    });

                    //staples
                    cfg.ReceiveEndpoint(RequestQueueName.GetStapleByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetStapleByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetStaplesRequest, e =>
                    {
                        e.ConfigureConsumer<GetStaplesRequestConsumer>(context);
                    });

                    //CropSeason
                    cfg.ReceiveEndpoint(RequestQueueName.GetCropSeasonByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCropSeasonByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCropSeasonsRequest, e =>
                    {
                        e.ConfigureConsumer<GetCropSeasonsRequestConsumer>(context);
                    });

                    //origins
                    cfg.ReceiveEndpoint(RequestQueueName.GetOriginByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetOriginByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetOriginsRequest, e =>
                    {
                        e.ConfigureConsumer<GetOriginsRequestConsumer>(context);
                    });

                    //SpinningProcess
                    cfg.ReceiveEndpoint(RequestQueueName.GetSpinningProcessByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSpinningProcessByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSpinningProcessesRequest, e =>
                    {
                        e.ConfigureConsumer<GetSpinningProcessesRequestConsumer>(context);
                    });

                    //SupplierType
                    cfg.ReceiveEndpoint(RequestQueueName.GetSupplierTypeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSupplierTypeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSupplierTypesRequest, e =>
                    {
                        e.ConfigureConsumer<GetSupplierTypesRequestConsumer>(context);
                    });

                    //PaymentTerms
                    cfg.ReceiveEndpoint(RequestQueueName.GetPaymentTermByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetPaymentTermByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPaymentTermsRequest, e =>
                    {
                        e.ConfigureConsumer<GetPaymentTermsRequestConsumer>(context);
                    });

                    //DeliveryTerms
                    cfg.ReceiveEndpoint(RequestQueueName.GetDeliveryTermByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetDeliveryTermByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetDeliveryTermsRequest, e =>
                    {
                        e.ConfigureConsumer<GetDeliveryTermsRequestConsumer>(context);
                    });

                    //Country
                    cfg.ReceiveEndpoint(RequestQueueName.GetCountryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCountryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCountriesRequest, e =>
                    {
                        e.ConfigureConsumer<GetCountriesRequestConsumer>(context);
                    });

                    //BuyerTypes
                    cfg.ReceiveEndpoint(RequestQueueName.GetBuyerTypeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetBuyerTypeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetBuyerTypesRequest, e =>
                    {
                        e.ConfigureConsumer<GetBuyerTypesRequestConsumer>(context);
                    });

                    //Gender
                    cfg.ReceiveEndpoint(RequestQueueName.GetGenderByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetGenderByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetGendersRequest, e =>
                    {
                        e.ConfigureConsumer<GetGendersRequestConsumer>(context);
                    });

                    //ProductGroup
                    cfg.ReceiveEndpoint(RequestQueueName.GetProductGroupByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetProductGroupByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetProductGroupsRequest, e =>
                    {
                        e.ConfigureConsumer<GetProductGroupsRequestConsumer>(context);
                    });

                    //MaterialType
                    cfg.ReceiveEndpoint(RequestQueueName.GetMaterialTypeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetMaterialTypeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetMaterialTypesRequest, e =>
                    {
                        e.ConfigureConsumer<GetMaterialTypesRequestConsumer>(context);
                    });

                    //SubCategories
                    cfg.ReceiveEndpoint(RequestQueueName.GetSubCategoryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSubCategoryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSubCategoriesRequest, e =>
                    {
                        e.ConfigureConsumer<GetSubCategoriesRequestConsumer>(context);
                    });

                    //UOMConversions
                    cfg.ReceiveEndpoint(RequestQueueName.GetUOMConversionByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetUOMConversionByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetUOMConversionsRequest, e =>
                    {
                        e.ConfigureConsumer<GetUOMConversionsRequestConsumer>(context);
                    });
                    //ShipmentTerm
                    cfg.ReceiveEndpoint(RequestQueueName.GetShipmentTermByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetShipmentTermByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetShipmentTermsRequest, e =>
                    {
                        e.ConfigureConsumer<GetShipmentTermsRequestConsumer>(context);
                    });

                    //Port
                    cfg.ReceiveEndpoint(RequestQueueName.GetPortByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetPortByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPortsRequest, e =>
                    {
                        e.ConfigureConsumer<GetPortsRequestConsumer>(context);
                    });

                    //UOM
                    cfg.ReceiveEndpoint(RequestQueueName.GetUOMByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetUOMByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetUOMsRequest, e =>
                    {
                        e.ConfigureConsumer<GetUOMsRequestConsumer>(context);
                    });

                    //Pattern
                    cfg.ReceiveEndpoint(RequestQueueName.GetPatternByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetPatternByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPatternsRequest, e =>
                    {
                        e.ConfigureConsumer<GetPatternsRequestConsumer>(context);
                    });

                    //Department
                    cfg.ReceiveEndpoint(RequestQueueName.GetDepartmentByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetDepartmentByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetDepartmentsRequest, e =>
                    {
                        e.ConfigureConsumer<GetDepartmentsRequestConsumer>(context);
                    });
                    //AccountGroup
                    cfg.ReceiveEndpoint(RequestQueueName.GetAccountGroupByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetAccountGroupByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetAccountGroupsRequest, e =>
                    {
                        e.ConfigureConsumer<GetAccountGroupsRequestConsumer>(context);
                    });
                    //GroupName
                    cfg.ReceiveEndpoint(RequestQueueName.GetGroupNameByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetGroupNameByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetGroupNamesRequest, e =>
                    {
                        e.ConfigureConsumer<GetGroupNamesRequestConsumer>(context);
                    });
                    //Gauge
                    cfg.ReceiveEndpoint(RequestQueueName.GetGaugeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetGaugeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetGaugesRequest, e =>
                    {
                        e.ConfigureConsumer<GetGaugesRequestConsumer>(context);
                    });
                    //MachineType
                    cfg.ReceiveEndpoint(RequestQueueName.GetMachineTypeByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetMachineTypeByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetMachineTypesRequest, e =>
                    {
                        e.ConfigureConsumer<GetMachineTypesRequestConsumer>(context);
                    });
                    //Article
                    cfg.ReceiveEndpoint(RequestQueueName.GetArticleByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetArticleByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetArticlesByIdsRequest, e =>
                    {
                        e.ConfigureConsumer<GetArticlesByIdsRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetArticlessRequest, e =>
                    {
                        e.ConfigureConsumer<GetArticlessRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetArticlesRequest, e =>
                    {
                        e.ConfigureConsumer<GetArticlesRequestConsumer>(context);
                    });
                    //Process
                    cfg.ReceiveEndpoint(RequestQueueName.GetProcessByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetProcessByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetProcessesRequest, e =>
                    {
                        e.ConfigureConsumer<GetProcessesRequestConsumer>(context);
                    });
                    //OperationLibrary
                    cfg.ReceiveEndpoint(RequestQueueName.GetOperationLibraryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetOperationLibraryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetOperationLibrariesRequest, e =>
                    {
                        e.ConfigureConsumer<GetOperationLibrariesRequestConsumer>(context);
                    });
                    //SubOperationLibrary
                    cfg.ReceiveEndpoint(RequestQueueName.GetSubOperationLibraryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetSubOperationLibraryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetSubOperationLibrariesRequest, e =>
                    {
                        e.ConfigureConsumer<GetSubOperationLibrariesRequestConsumer>(context);
                    });
                    //Division
                    cfg.ReceiveEndpoint(RequestQueueName.GetDivisionByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetDivisionByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetDivisionsRequest, e =>
                    {
                        e.ConfigureConsumer<GetDivisionsRequestConsumer>(context);
                    });

                    // Machine
                    cfg.ReceiveEndpoint(RequestQueueName.GetMachineByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetMachineByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetMachinesRequest, e =>
                    {
                        e.ConfigureConsumer<GetMachinesRequestConsumer>(context);
                    });

                    // Line
                    cfg.ReceiveEndpoint(RequestQueueName.GetLineByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetLineByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetLinesRequest, e =>
                    {
                        e.ConfigureConsumer<GetLinesRequestConsumer>(context);
                    });

                    // PlanningGroup
                    cfg.ReceiveEndpoint(RequestQueueName.GetPlanningGroupByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetPlanningGroupByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPlanningGroupsRequest, e =>
                    {
                        e.ConfigureConsumer<GetPlanningGroupsRequestConsumer>(context);
                    });

                    // PlanningGroupFactory
                    cfg.ReceiveEndpoint(RequestQueueName.GetPlanningGroupFactoryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetPlanningGroupFactoryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPlanningGroupFactoriesRequest, e =>
                    {
                        e.ConfigureConsumer<GetPlanningGroupFactoriesRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetPlanningGroupFactoryByIdsRequest, e =>
                    {
                        e.ConfigureConsumer<GetPlanningGroupFactoryByIdsRequestConsumer>(context);
                    });

                    // Calendar
                    cfg.ReceiveEndpoint(RequestQueueName.GetCalendarByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetCalendarByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCalendarByIdsRequest, e =>
                    {
                        e.ConfigureConsumer<GetCalendarByIdsRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetCalendarsRequest, e =>
                    {
                        e.ConfigureConsumer<GetCalendarsRequestConsumer>(context);
                    });

                    // Holiday
                    cfg.ReceiveEndpoint(RequestQueueName.GetHolidayByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetHolidayByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetHolidaysRequest, e =>
                    {
                        e.ConfigureConsumer<GetHolidaysRequestConsumer>(context);
                    });

                    // Factory
                    cfg.ReceiveEndpoint(RequestQueueName.GetFactoryByIdRequest, e =>
                    {
                        e.ConfigureConsumer<GetFactoryByIdRequestConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RequestQueueName.GetFactoriesRequest, e =>
                    {
                        e.ConfigureConsumer<GetFactoriesRequestConsumer>(context);
                    });

                    // Data Calculate
                    cfg.ReceiveEndpoint(RequestQueueName.GetDataCalculateRequest, e =>
                    {
                        e.ConfigureConsumer<GetDataCalculateRequestConsumer>(context);
                    });
                });
                #endregion
            });
            services.AddEventBusService();
        }
    }
}
