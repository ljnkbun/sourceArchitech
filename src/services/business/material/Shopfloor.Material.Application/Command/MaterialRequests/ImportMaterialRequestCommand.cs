using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.Divisions;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Divisions;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.MaterialRequests;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class ImportMaterialRequestCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public IFormFile File { get; set; }

        public string Type { get; set; }
    }

    public class ImportMaterialRequestCommandHandler : IRequestHandler<ImportMaterialRequestCommand, Core.Models.Responses.Response<bool>>
    {
        private readonly IMaterialRequestRepository _repository;

        private readonly IDynamicColumnRepository _repositoryDynamicColumn;

        private readonly IRequestClientService _requestClientService;

        private readonly IMapper _mapper;

        public ImportMaterialRequestCommandHandler(IMaterialRequestRepository repository, IMapper mapper, IRequestClientService requestClientService, IDynamicColumnRepository repositoryDynamicColumn)
        {
            _repository = repository;
            _mapper = mapper;
            _requestClientService = requestClientService;
            _repositoryDynamicColumn = repositoryDynamicColumn;
        }

        public async Task<Core.Models.Responses.Response<bool>> Handle(ImportMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            ImportExcelModel input;
            var materialRequests = new List<MaterialRequest>();
            var productCategories = await _requestClientService.GetResponseAsync<GetCategoriesRequest, GetCategoriesResponse>(new GetCategoriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue,
                Code = request.Type.ToUpper()
            });
            var productCategory = productCategories?.Message.Data.FirstOrDefault();
            if (productCategory == null)
            {
                return new Core.Models.Responses.Response<bool>(false, "Product Category Not Found");
            }
            switch (request.Type)
            {
                case MaterialRequestType.Trims:
                    {
                        input = new ImportExcelModel(0, 2, FieldMaps.TrimsRequest);
                        var data = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(request.File, input);
                        if (data == null || data.Count == 0)
                        {
                            return new Core.Models.Responses.Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(subCategoriesTask);

                        var colorDefinitionTask = _requestClientService.GetResponseAsync<GetColorDefinitionsRequest, GetColorDefinitionsResponse>(new GetColorDefinitionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(colorDefinitionTask);

                        var colorCardTask = _requestClientService.GetResponseAsync<GetColorCardsRequest, GetColorCardsResponse>(new GetColorCardsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(colorCardTask);

                        var sizeGroupTask = _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(sizeGroupTask);

                        var seasonTask = _requestClientService.GetResponseAsync<GetCropSeasonsRequest, GetCropSeasonsResponse>(new GetCropSeasonsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(seasonTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(materialTypeTask);

                        var divisionTask = _requestClientService.GetResponseAsync<GetDivisionsRequest, GetDivisionsResponse>(new GetDivisionsRequest()
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(divisionTask);

                        var pricePerTask = _requestClientService.GetResponseAsync<GetPricePersRequest, GetPricePersResponse>(new GetPricePersRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(pricePerTask);

                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(companyCurrenciesTask);

                        await Task.WhenAll(tasks);
                        var productGroup = productGroupTask.Result;
                        var subCategories = subCategoriesTask.Result;
                        var colorDefinition = colorDefinitionTask.Result;
                        var colorCard = colorCardTask.Result;
                        var sizeGroup = sizeGroupTask.Result;
                        var season = seasonTask.Result;
                        var materialType = materialTypeTask.Result;
                        var uom = uomTask.Result;
                        var division = divisionTask.Result;
                        var companyCurrencies = companyCurrenciesTask.Result;
                        var pricePer = pricePerTask.Result;

                        foreach (var materialRequest in data)
                        {
                            var item = _mapper.Map<MaterialRequest>(materialRequest);
                            item.Status = ProcessStatus.Draft;
                            var dataProductGroup = productGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductGroupCode?.Trim() || v.Code == materialRequest.ProductGroupCode?.Trim());
                            var dataProductSubCat = subCategories?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductSubCatCode?.Trim() || v.Code == materialRequest.ProductSubCatCode?.Trim());
                            var dataColorType = colorDefinition?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ColorTypeCode?.Trim() || v.Code == materialRequest.ColorTypeCode?.Trim());
                            var dataColorGroup = colorCard?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ColorGroupCode?.Trim() || v.Code == materialRequest.ColorGroupCode?.Trim());
                            var dataSizeGroup = sizeGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.SizeGroupCode?.Trim() || v.Code == materialRequest.SizeGroupCode?.Trim());
                            var dataSeason = season?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.SeasonCode?.Trim() || v.Code == materialRequest.SeasonCode?.Trim());
                            var dataMaterialType = materialType?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.MaterialTypeCode?.Trim() || v.Code == materialRequest.MaterialTypeCode?.Trim());
                            var dataUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.UomCode?.Trim() || v.Code == materialRequest.UomCode?.Trim());
                            var dataStoringUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.StoringUomCode?.Trim() || v.Code == materialRequest.StoringUomCode?.Trim());
                            var dataConsUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ConsUomCode?.Trim() || v.Code == materialRequest.ConsUomCode?.Trim());
                            var dataDivision = division?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.DivisionCode?.Trim() || v.Code == materialRequest.DivisionCode?.Trim());
                            var dataCompanyCurrencies = companyCurrencies?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.BuyingCurrencyCode?.Trim() || v.Code == materialRequest.BuyingCurrencyCode?.Trim());
                            var dataPricePer = pricePer?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.PricePerCode?.Trim() || v.Code == materialRequest.PricePerCode?.Trim());
                            var dicRequiredString = new Dictionary<string, string>();
                            dicRequiredString.Add(nameof(dataPricePer), materialRequest.PricePerCode);
                            dicRequiredString.Add(nameof(dataCompanyCurrencies), materialRequest.BuyingCurrencyCode);
                            dicRequiredString.Add(nameof(dataDivision), materialRequest.DivisionCode);
                            dicRequiredString.Add(nameof(dataConsUom), materialRequest.ConsUomCode);
                            dicRequiredString.Add(nameof(dataStoringUom), materialRequest.StoringUomCode);
                            dicRequiredString.Add(nameof(dataUom), materialRequest.UomCode);
                            dicRequiredString.Add(nameof(dataMaterialType), materialRequest.MaterialTypeCode);
                            dicRequiredString.Add(nameof(dataSeason), materialRequest.SeasonCode);
                            dicRequiredString.Add(nameof(dataSizeGroup), materialRequest.SizeGroupCode);
                            dicRequiredString.Add(nameof(dataColorGroup), materialRequest.ColorGroupCode);
                            dicRequiredString.Add(nameof(dataColorType), materialRequest.ColorTypeCode);
                            dicRequiredString.Add(nameof(dataProductSubCat), materialRequest.ProductSubCatCode);
                            dicRequiredString.Add(nameof(dataProductGroup), materialRequest.ProductGroupCode);
                            foreach (var i in dicRequiredString)
                            {
                                switch (i.Key)
                                {
                                    case nameof(dataPricePer):
                                        {
                                            if (dataPricePer == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Price Per -Article Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataCompanyCurrencies):
                                        {
                                            if (dataCompanyCurrencies == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Selling Price-Currency Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataDivision):
                                        {
                                            if (dataDivision == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Company Division Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataConsUom):
                                        {
                                            if (dataConsUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Consumption UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataStoringUom):
                                        {
                                            if (dataStoringUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Storage UOM Not Found");
                                            }

                                            break;
                                        }
                                    case nameof(dataUom):
                                        {
                                            if (dataUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Purchase UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataMaterialType):
                                        {
                                            if (dataMaterialType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Material Type Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataSeason):
                                        {
                                            if (dataSeason == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Season Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataSizeGroup):
                                        {
                                            if (dataSizeGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Size Range Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataColorGroup):
                                        {
                                            if (dataColorGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Color Card Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataColorType):
                                        {
                                            if (dataColorType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Color Definition Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductSubCat):
                                        {
                                            if (dataProductSubCat == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Sub Category Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductGroup):
                                        {
                                            if (dataProductGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Product Group Not Found");
                                            }
                                            break;
                                        }
                                }
                            }
                            item.ProductGroupName = dataProductGroup?.Name;
                            item.ProductGroupCode = dataProductGroup?.Code;
                            item.ProductSubCatName = dataProductSubCat?.Name;
                            item.ProductSubCatCode = dataProductSubCat?.Code;
                            item.ColorTypeName = dataColorType?.Name;
                            item.ColorTypeCode = dataColorType?.Code;
                            item.ColorGroupName = dataColorGroup?.Name;
                            item.ColorGroupCode = dataColorGroup?.Code;
                            item.SizeGroupName = dataSizeGroup?.Name;
                            item.SizeGroupCode = dataSizeGroup?.Code;
                            item.SeasonName = dataSeason?.Name;
                            item.SeasonCode = dataSeason?.Code;
                            item.CropSeasonName = dataSeason?.Name;
                            item.CropSeasonCode = dataSeason?.Code;
                            item.MaterialTypeName = dataMaterialType?.Name;
                            item.MaterialTypeCode = dataMaterialType?.Code;
                            item.UomName = dataUom?.Name;
                            item.UomCode = dataUom?.Code;
                            item.StoringUomName = dataStoringUom?.Name;
                            item.StoringUomCode = dataStoringUom?.Code;
                            item.ConsUomName = dataConsUom?.Name;
                            item.ConsUomCode = dataConsUom?.Code;
                            item.DivisionName = dataDivision?.Name;
                            item.DivisionCode = dataDivision?.Code;
                            item.BuyingCurrencyName = dataCompanyCurrencies?.Name;
                            item.BuyingCurrencyCode = dataCompanyCurrencies?.Code;
                            item.PricePerName = dataPricePer?.Name;
                            item.PricePerCode = dataPricePer?.Code;
                            item.ProductCatName = productCategory?.Name;
                            item.ProductCatCode = productCategory?.Code;
                            var dicString = new Dictionary<string, string>();
                            dicString.Add(nameof(materialRequest.ButtonType), materialRequest.ButtonType);
                            dicString.Add(nameof(materialRequest.ButtonHole), materialRequest.ButtonHole);
                            dicString.Add(nameof(materialRequest.ElasticType), materialRequest.ElasticType);
                            dicString.Add(nameof(materialRequest.RivetType), materialRequest.RivetType);
                            dicString.Add(nameof(materialRequest.ZipperType), materialRequest.ZipperType);
                            dicString.Add(nameof(materialRequest.Layer), materialRequest.Layer);
                            dicString.Add(nameof(materialRequest.Brand), materialRequest.Brand);
                            dicString.Add(nameof(materialRequest.Tex), materialRequest.Tex);
                            var lstDataDynamicColumns = await _repositoryDynamicColumn.GetListByCodeAsync(dicString, MaterialRequestType.Trims);
                            if (lstDataDynamicColumns.Count != dicString.Count(x => !string.IsNullOrEmpty(x.Value)))
                            {
                                return new Core.Models.Responses.Response<bool>(false, "Dynamic Column wrong format");
                            }
                            foreach (var dc in lstDataDynamicColumns)
                            {
                                item.DynamicColumns.Add(new MaterialRequestDynamicColumn
                                {
                                    Value = dicString.FirstOrDefault(x => x.Key == dc.Code).Value,
                                    DynamicColumnId = dc.Id
                                });
                            }

                            materialRequests.Add(item);
                        }
                        break;
                    }
                case MaterialRequestType.Fabric:
                    {
                        input = new ImportExcelModel(0, 2, FieldMaps.FabricRequest);
                        var data = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(request.File, input);
                        if (data == null || data.Count == 0)
                        {
                            return new Core.Models.Responses.Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(subCategoriesTask);

                        var colorDefinitionTask = _requestClientService.GetResponseAsync<GetColorDefinitionsRequest, GetColorDefinitionsResponse>(new GetColorDefinitionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(colorDefinitionTask);

                        var colorCardTask = _requestClientService.GetResponseAsync<GetColorCardsRequest, GetColorCardsResponse>(new GetColorCardsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(colorCardTask);

                        var sizeGroupTask = _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(sizeGroupTask);

                        var seasonTask = _requestClientService.GetResponseAsync<GetCropSeasonsRequest, GetCropSeasonsResponse>(new GetCropSeasonsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(seasonTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(materialTypeTask);

                        var countTask = _requestClientService.GetResponseAsync<GetCountsRequest, GetCountsResponse>(new GetCountsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(countTask);

                        var fabricTask = _requestClientService.GetResponseAsync<GetFabricContentsRequest, GetFabricContentsResponse>(new GetFabricContentsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(fabricTask);

                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(companyCurrenciesTask);

                        var constructionTask = _requestClientService.GetResponseAsync<GetConstructionsRequest, GetConstructionsResponse>(new GetConstructionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(constructionTask);

                        var divisionTask = _requestClientService.GetResponseAsync<GetDivisionsRequest, GetDivisionsResponse>(new GetDivisionsRequest()
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(divisionTask);

                        var pricePerTask = _requestClientService.GetResponseAsync<GetPricePersRequest, GetPricePersResponse>(new GetPricePersRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(pricePerTask);

                        await Task.WhenAll(tasks);
                        var productGroup = productGroupTask.Result;
                        var subCategories = subCategoriesTask.Result;
                        var colorDefinition = colorDefinitionTask.Result;
                        var colorCard = colorCardTask.Result;
                        var sizeGroup = sizeGroupTask.Result;
                        var season = seasonTask.Result;
                        var materialType = materialTypeTask.Result;
                        var uom = uomTask.Result;
                        var division = divisionTask.Result;
                        var companyCurrencies = companyCurrenciesTask.Result;
                        var pricePer = pricePerTask.Result;
                        var construction = constructionTask.Result;
                        var count = countTask.Result;
                        var fabric = fabricTask.Result;

                        foreach (var materialRequest in data)
                        {
                            var item = _mapper.Map<MaterialRequest>(materialRequest);
                            item.Status = ProcessStatus.Draft;
                            var dataProductGroup = productGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductGroupCode?.Trim() || v.Code == materialRequest.ProductGroupCode?.Trim());
                            var dataProductSubCat = subCategories?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductSubCatCode?.Trim() || v.Code == materialRequest.ProductSubCatCode?.Trim());
                            var dataColorType = colorDefinition?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ColorTypeCode?.Trim() || v.Code == materialRequest.ColorTypeCode?.Trim());
                            var dataColorGroup = colorCard?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ColorGroupCode?.Trim() || v.Code == materialRequest.ColorGroupCode?.Trim());
                            var dataSizeGroup = sizeGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.SizeGroupCode?.Trim() || v.Code == materialRequest.SizeGroupCode?.Trim());
                            var dataSeason = season?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.SeasonCode?.Trim() || v.Code == materialRequest.SeasonCode?.Trim());
                            var dataMaterialType = materialType?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.MaterialTypeCode?.Trim() || v.Code == materialRequest.MaterialTypeCode?.Trim());
                            var dataUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.UomCode?.Trim() || v.Code == materialRequest.UomCode?.Trim());
                            var dataStoringUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.StoringUomCode?.Trim() || v.Code == materialRequest.StoringUomCode?.Trim());
                            var dataConsUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ConsUomCode?.Trim() || v.Code == materialRequest.ConsUomCode?.Trim());
                            var dataDivision = division?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.DivisionCode?.Trim() || v.Code == materialRequest.DivisionCode?.Trim());
                            var dataCompanyCurrencies = companyCurrencies?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.BuyingCurrencyCode?.Trim() || v.Code == materialRequest.BuyingCurrencyCode?.Trim());
                            var dataPricePer = pricePer?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.PricePerCode?.Trim() || v.Code == materialRequest.PricePerCode?.Trim());
                            var dataConstruction = construction?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ConstructionCode?.Trim() || v.Code == materialRequest.ConstructionCode?.Trim());
                            var dataCount = count?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.CountCode?.Trim() || v.Code == materialRequest.CountCode?.Trim());
                            var dicRequiredString = new Dictionary<string, string>();
                            dicRequiredString.Add(nameof(dataPricePer), materialRequest.PricePerCode);
                            dicRequiredString.Add(nameof(dataCompanyCurrencies), materialRequest.BuyingCurrencyCode);
                            dicRequiredString.Add(nameof(dataDivision), materialRequest.DivisionCode);
                            dicRequiredString.Add(nameof(dataConsUom), materialRequest.ConsUomCode);
                            dicRequiredString.Add(nameof(dataStoringUom), materialRequest.StoringUomCode);
                            dicRequiredString.Add(nameof(dataUom), materialRequest.UomCode);
                            dicRequiredString.Add(nameof(dataMaterialType), materialRequest.MaterialTypeCode);
                            dicRequiredString.Add(nameof(dataSeason), materialRequest.SeasonCode);
                            dicRequiredString.Add(nameof(dataSizeGroup), materialRequest.SizeGroupCode);
                            dicRequiredString.Add(nameof(dataColorGroup), materialRequest.ColorGroupCode);
                            dicRequiredString.Add(nameof(dataColorType), materialRequest.ColorTypeCode);
                            dicRequiredString.Add(nameof(dataProductSubCat), materialRequest.ProductSubCatCode);
                            dicRequiredString.Add(nameof(dataProductGroup), materialRequest.ProductGroupCode);
                            dicRequiredString.Add(nameof(dataConstruction), materialRequest.ConstructionCode);
                            dicRequiredString.Add(nameof(dataCount), materialRequest.CountCode);
                            foreach (var i in dicRequiredString)
                            {
                                switch (i.Key)
                                {
                                    case nameof(dataCount):
                                        {
                                            if (dataCount == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Count Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataConstruction):
                                        {
                                            if (dataConstruction == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Construction Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataPricePer):
                                        {
                                            if (dataPricePer == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Price Per -Article Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataCompanyCurrencies):
                                        {
                                            if (dataCompanyCurrencies == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Buying Price-Currency Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataDivision):
                                        {
                                            if (dataDivision == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Company Division Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataConsUom):
                                        {
                                            if (dataConsUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Consumption UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataStoringUom):
                                        {
                                            if (dataStoringUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Storage UOM Not Found");
                                            }

                                            break;
                                        }
                                    case nameof(dataUom):
                                        {
                                            if (dataUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Purchase UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataMaterialType):
                                        {
                                            if (dataMaterialType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Material Type Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataSeason):
                                        {
                                            if (dataSeason == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Season Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataSizeGroup):
                                        {
                                            if (dataSizeGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Size Range Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataColorGroup):
                                        {
                                            if (dataColorGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Color Card Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataColorType):
                                        {
                                            if (dataColorType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Color Definition Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductSubCat):
                                        {
                                            if (dataProductSubCat == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Sub Category Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductGroup):
                                        {
                                            if (dataProductGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Product Group Not Found");
                                            }
                                            break;
                                        }
                                }
                            }
                            if (!string.IsNullOrEmpty(materialRequest.FabricComposition) && fabric.Message.Data != null)
                            {
                                foreach (var c in materialRequest.FabricComposition.Split(','))
                                {
                                    var subDataContentName = c.Split(':');
                                    if (subDataContentName.Any())
                                    {
                                        var firstData = fabric.Message.Data?.FirstOrDefault(i => i.Name.Equals(subDataContentName?.FirstOrDefault(), StringComparison.OrdinalIgnoreCase));
                                        var lastData = subDataContentName?.LastOrDefault();
                                        if (firstData != null)
                                        {
                                            item.FabricCompositions.Add(new FabricComposition
                                            {
                                                ContentNameDesc = firstData.Name,
                                                Percentage = lastData.IsNumber() ? Convert.ToDecimal(lastData) : 0,
                                            });
                                        }
                                        else
                                        {
                                            return new Core.Models.Responses.Response<bool>(false, "Fabric Composition Not Found");
                                        }
                                    }
                                }
                            }
                            item.ProductGroupName = dataProductGroup?.Name;
                            item.ProductGroupCode = dataProductGroup?.Code;
                            item.ProductSubCatName = dataProductSubCat?.Name;
                            item.ProductSubCatCode = dataProductSubCat?.Code;
                            item.ColorTypeName = dataColorType?.Name;
                            item.ColorTypeCode = dataColorType?.Code;
                            item.ColorGroupName = dataColorGroup?.Name;
                            item.ColorGroupCode = dataColorGroup?.Code;
                            item.SizeGroupName = dataSizeGroup?.Name;
                            item.SizeGroupCode = dataSizeGroup?.Code;
                            item.SeasonName = dataSeason?.Name;
                            item.SeasonCode = dataSeason?.Code;
                            item.CropSeasonName = dataSeason?.Name;
                            item.CropSeasonCode = dataSeason?.Code;
                            item.MaterialTypeName = dataMaterialType?.Name;
                            item.MaterialTypeCode = dataMaterialType?.Code;
                            item.UomName = dataUom?.Name;
                            item.UomCode = dataUom?.Code;
                            item.StoringUomName = dataStoringUom?.Name;
                            item.StoringUomCode = dataStoringUom?.Code;
                            item.ConsUomName = dataConsUom?.Name;
                            item.ConsUomCode = dataConsUom?.Code;
                            item.DivisionName = dataDivision?.Name;
                            item.DivisionCode = dataDivision?.Code;
                            item.BuyingCurrencyName = dataCompanyCurrencies?.Name;
                            item.BuyingCurrencyCode = dataCompanyCurrencies?.Code;
                            item.PricePerName = dataPricePer?.Name;
                            item.PricePerCode = dataPricePer?.Code;
                            item.ProductCatName = productCategory?.Name;
                            item.ProductCatCode = productCategory?.Code;
                            item.ConstructionName = dataConstruction?.Name;
                            item.ConstructionCode = dataConstruction?.Code;
                            item.CountName = dataCount?.Name;
                            item.CountCode = dataCount?.Code;
                            var dicString = new Dictionary<string, string>();
                            dicString.Add(nameof(materialRequest.TCFNO), materialRequest.TCFNO);
                            dicString.Add(nameof(materialRequest.GSM), materialRequest.GSM);
                            dicString.Add(nameof(materialRequest.NoOfEnds), materialRequest.NoOfEnds);
                            dicString.Add(nameof(materialRequest.SpinningMethod), materialRequest.SpinningMethod);
                            dicString.Add(nameof(materialRequest.Certificate), materialRequest.Certificate);
                            dicString.Add(nameof(materialRequest.Gauge), materialRequest.Gauge);
                            dicString.Add(nameof(materialRequest.StitchLength), materialRequest.StitchLength);
                            dicString.Add(nameof(materialRequest.YarnComposition), materialRequest.YarnComposition);
                            dicString.Add(nameof(materialRequest.CutWidth), materialRequest.CutWidth);
                            dicString.Add(nameof(materialRequest.Structure), materialRequest.Structure);
                            var lstDataDynamicColumns = await _repositoryDynamicColumn.GetListByCodeAsync(dicString, MaterialRequestType.Fabric);
                            if (lstDataDynamicColumns.Count != dicString.Count(x => !string.IsNullOrEmpty(x.Value)))
                            {
                                return new Core.Models.Responses.Response<bool>(false, "Dynamic Column wrong format");
                            }
                            foreach (var dc in lstDataDynamicColumns)
                            {
                                item.DynamicColumns.Add(new MaterialRequestDynamicColumn
                                {
                                    Value = dicString.FirstOrDefault(x => x.Key == dc.Code).Value,
                                    DynamicColumnId = dc.Id
                                });
                            }

                            materialRequests.Add(item);
                        }
                        break;
                    }
                case MaterialRequestType.Misc:
                    {
                        input = new ImportExcelModel(0, 2, FieldMaps.MiscRequest);
                        var data = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(request.File, input);
                        if (data == null || data.Count == 0)
                        {
                            return new Core.Models.Responses.Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(subCategoriesTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(materialTypeTask);

                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(companyCurrenciesTask);

                        await Task.WhenAll(tasks);
                        var productGroup = productGroupTask.Result;
                        var subCategories = subCategoriesTask.Result;
                        var materialType = materialTypeTask.Result;
                        var uom = uomTask.Result;
                        var companyCurrencies = companyCurrenciesTask.Result;

                        foreach (var materialRequest in data)
                        {
                            var item = _mapper.Map<MaterialRequest>(materialRequest);
                            item.Status = ProcessStatus.Draft;
                            var dataProductGroup = productGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductGroupCode?.Trim() || v.Code == materialRequest.ProductGroupCode?.Trim());
                            var dataProductSubCat = subCategories?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductSubCatCode?.Trim() || v.Code == materialRequest.ProductSubCatCode?.Trim());
                            var dataMaterialType = materialType?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.MaterialTypeCode?.Trim() || v.Code == materialRequest.MaterialTypeCode?.Trim());
                            var dataUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.UomCode?.Trim() || v.Code == materialRequest.UomCode?.Trim());
                            var dataStoringUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.StoringUomCode?.Trim() || v.Code == materialRequest.StoringUomCode?.Trim());
                            var dataCompanyCurrencies = companyCurrencies?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.BuyingCurrencyCode?.Trim() || v.Code == materialRequest.BuyingCurrencyCode?.Trim());
                            var dicRequiredString = new Dictionary<string, string>();
                            dicRequiredString.Add(nameof(dataCompanyCurrencies), materialRequest.BuyingCurrencyCode);
                            dicRequiredString.Add(nameof(dataStoringUom), materialRequest.StoringUomCode);
                            dicRequiredString.Add(nameof(dataUom), materialRequest.UomCode);
                            dicRequiredString.Add(nameof(dataMaterialType), materialRequest.MaterialTypeCode);
                            dicRequiredString.Add(nameof(dataProductSubCat), materialRequest.ProductSubCatCode);
                            dicRequiredString.Add(nameof(dataProductGroup), materialRequest.ProductGroupCode);
                            foreach (var i in dicRequiredString)
                            {
                                switch (i.Key)
                                {
                                    case nameof(dataCompanyCurrencies):
                                        {
                                            if (dataCompanyCurrencies == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Buying Price-Currency Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataStoringUom):
                                        {
                                            if (dataStoringUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Storage UOM Not Found");
                                            }

                                            break;
                                        }
                                    case nameof(dataUom):
                                        {
                                            if (dataUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Purchase UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataMaterialType):
                                        {
                                            if (dataMaterialType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Material Type Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductSubCat):
                                        {
                                            if (dataProductSubCat == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Sub Category Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductGroup):
                                        {
                                            if (dataProductGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Product Group Not Found");
                                            }
                                            break;
                                        }
                                }
                            }
                            item.ProductGroupName = dataProductGroup?.Name;
                            item.ProductGroupCode = dataProductGroup?.Code;
                            item.ProductSubCatName = dataProductSubCat?.Name;
                            item.ProductSubCatCode = dataProductSubCat?.Code;
                            item.MaterialTypeName = dataMaterialType?.Name;
                            item.MaterialTypeCode = dataMaterialType?.Code;
                            item.UomName = dataUom?.Name;
                            item.UomCode = dataUom?.Code;
                            item.StoringUomName = dataStoringUom?.Name;
                            item.StoringUomCode = dataStoringUom?.Code;
                            item.BuyingCurrencyName = dataCompanyCurrencies?.Name;
                            item.BuyingCurrencyCode = dataCompanyCurrencies?.Code;
                            item.ProductCatName = productCategory?.Name;
                            item.ProductCatCode = productCategory?.Code;
                            materialRequests.Add(item);
                        }
                        break;
                    }
                case MaterialRequestType.Yarns:
                    {
                        input = new ImportExcelModel(0, 2, FieldMaps.YarnsRequest);
                        var data = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(request.File, input);
                        if (data == null || data.Count == 0)
                        {
                            return new Core.Models.Responses.Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(subCategoriesTask);

                        var colorDefinitionTask = _requestClientService.GetResponseAsync<GetColorDefinitionsRequest, GetColorDefinitionsResponse>(new GetColorDefinitionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(colorDefinitionTask);

                        var colorCardTask = _requestClientService.GetResponseAsync<GetColorCardsRequest, GetColorCardsResponse>(new GetColorCardsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(colorCardTask);

                        var sizeGroupTask = _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(sizeGroupTask);

                        var seasonTask = _requestClientService.GetResponseAsync<GetCropSeasonsRequest, GetCropSeasonsResponse>(new GetCropSeasonsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(seasonTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(materialTypeTask);

                        var countTask = _requestClientService.GetResponseAsync<GetCountsRequest, GetCountsResponse>(new GetCountsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(countTask);
                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(companyCurrenciesTask);

                        var constructionTask = _requestClientService.GetResponseAsync<GetConstructionsRequest, GetConstructionsResponse>(new GetConstructionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(constructionTask);

                        var divisionTask = _requestClientService.GetResponseAsync<GetDivisionsRequest, GetDivisionsResponse>(new GetDivisionsRequest()
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(divisionTask);

                        var pricePerTask = _requestClientService.GetResponseAsync<GetPricePersRequest, GetPricePersResponse>(new GetPricePersRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        });
                        tasks.Add(pricePerTask);
                        await Task.WhenAll(tasks);
                        var productGroup = productGroupTask.Result;
                        var subCategories = subCategoriesTask.Result;
                        var colorDefinition = colorDefinitionTask.Result;
                        var colorCard = colorCardTask.Result;
                        var sizeGroup = sizeGroupTask.Result;
                        var season = seasonTask.Result;
                        var materialType = materialTypeTask.Result;
                        var uom = uomTask.Result;
                        var division = divisionTask.Result;
                        var companyCurrencies = companyCurrenciesTask.Result;
                        var pricePer = pricePerTask.Result;
                        var construction = constructionTask.Result;
                        var count = countTask.Result;

                        foreach (var materialRequest in data)
                        {
                            var item = _mapper.Map<MaterialRequest>(materialRequest);
                            item.Status = ProcessStatus.Draft;
                            var dataProductGroup = productGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductGroupCode?.Trim() || v.Code == materialRequest.ProductGroupCode?.Trim());
                            var dataProductSubCat = subCategories?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ProductSubCatCode?.Trim() || v.Code == materialRequest.ProductSubCatCode?.Trim());
                            var dataColorType = colorDefinition?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ColorTypeCode?.Trim() || v.Code == materialRequest.ColorTypeCode?.Trim());
                            var dataColorGroup = colorCard?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ColorGroupCode?.Trim() || v.Code == materialRequest.ColorGroupCode?.Trim());
                            var dataSizeGroup = sizeGroup?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.SizeGroupCode?.Trim() || v.Code == materialRequest.SizeGroupCode?.Trim());
                            var dataSeason = season?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.SeasonCode?.Trim() || v.Code == materialRequest.SeasonCode?.Trim());
                            var dataMaterialType = materialType?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.MaterialTypeCode?.Trim() || v.Code == materialRequest.MaterialTypeCode?.Trim());
                            var dataUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.UomCode?.Trim() || v.Code == materialRequest.UomCode?.Trim());
                            var dataStoringUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.StoringUomCode?.Trim() || v.Code == materialRequest.StoringUomCode?.Trim());
                            var dataConsUom = uom?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ConsUomCode?.Trim() || v.Code == materialRequest.ConsUomCode?.Trim());
                            var dataDivision = division?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.DivisionCode?.Trim() || v.Code == materialRequest.DivisionCode?.Trim());
                            var dataCompanyCurrencies = companyCurrencies?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.BuyingCurrencyCode?.Trim() || v.Code == materialRequest.BuyingCurrencyCode?.Trim());
                            var dataPricePer = pricePer?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.PricePerCode?.Trim() || v.Code == materialRequest.PricePerCode?.Trim());
                            var dataConstruction = construction?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.ConstructionCode?.Trim() || v.Code == materialRequest.ConstructionCode?.Trim());
                            var dataCount = count?.Message?.Data?.FirstOrDefault(v => v.Name == materialRequest.CountCode?.Trim() || v.Code == materialRequest.CountCode?.Trim());
                            var dicRequiredString = new Dictionary<string, string>();
                            dicRequiredString.Add(nameof(dataPricePer), materialRequest.PricePerCode);
                            dicRequiredString.Add(nameof(dataCompanyCurrencies), materialRequest.BuyingCurrencyCode);
                            dicRequiredString.Add(nameof(dataDivision), materialRequest.DivisionCode);
                            dicRequiredString.Add(nameof(dataConsUom), materialRequest.ConsUomCode);
                            dicRequiredString.Add(nameof(dataStoringUom), materialRequest.StoringUomCode);
                            dicRequiredString.Add(nameof(dataUom), materialRequest.UomCode);
                            dicRequiredString.Add(nameof(dataMaterialType), materialRequest.MaterialTypeCode);
                            dicRequiredString.Add(nameof(dataSeason), materialRequest.SeasonCode);
                            dicRequiredString.Add(nameof(dataSizeGroup), materialRequest.SizeGroupCode);
                            dicRequiredString.Add(nameof(dataColorGroup), materialRequest.ColorGroupCode);
                            dicRequiredString.Add(nameof(dataColorType), materialRequest.ColorTypeCode);
                            dicRequiredString.Add(nameof(dataProductSubCat), materialRequest.ProductSubCatCode);
                            dicRequiredString.Add(nameof(dataProductGroup), materialRequest.ProductGroupCode);
                            dicRequiredString.Add(nameof(dataConstruction), materialRequest.ConstructionCode);
                            dicRequiredString.Add(nameof(dataCount), materialRequest.CountCode);
                            foreach (var i in dicRequiredString)
                            {
                                switch (i.Key)
                                {
                                    case nameof(dataCount):
                                        {
                                            if (dataCount == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Count Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataConstruction):
                                        {
                                            if (dataConstruction == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Construction Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataPricePer):
                                        {
                                            if (dataPricePer == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Price Per -Article Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataCompanyCurrencies):
                                        {
                                            if (dataCompanyCurrencies == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Buying Price-Currency Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataDivision):
                                        {
                                            if (dataDivision == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Company Division Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataConsUom):
                                        {
                                            if (dataConsUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Consumption UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataStoringUom):
                                        {
                                            if (dataStoringUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Storage UOM Not Found");
                                            }

                                            break;
                                        }
                                    case nameof(dataUom):
                                        {
                                            if (dataUom == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Purchase UOM Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataMaterialType):
                                        {
                                            if (dataMaterialType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Material Type Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataSeason):
                                        {
                                            if (dataSeason == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Season Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataSizeGroup):
                                        {
                                            if (dataSizeGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Size Range Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataColorGroup):
                                        {
                                            if (dataColorGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Color Card Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataColorType):
                                        {
                                            if (dataColorType == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Color Definition Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductSubCat):
                                        {
                                            if (dataProductSubCat == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Sub Category Not Found");
                                            }
                                            break;
                                        }
                                    case nameof(dataProductGroup):
                                        {
                                            if (dataProductGroup == null && !string.IsNullOrEmpty(i.Value))
                                            {
                                                return new Core.Models.Responses.Response<bool>(false, "Product Group Not Found");
                                            }
                                            break;
                                        }
                                }
                            }
                            item.ProductGroupName = dataProductGroup?.Name;
                            item.ProductGroupCode = dataProductGroup?.Code;
                            item.ProductSubCatName = dataProductSubCat?.Name;
                            item.ProductSubCatCode = dataProductSubCat?.Code;
                            item.ColorTypeName = dataColorType?.Name;
                            item.ColorTypeCode = dataColorType?.Code;
                            item.ColorGroupName = dataColorGroup?.Name;
                            item.ColorGroupCode = dataColorGroup?.Code;
                            item.SizeGroupName = dataSizeGroup?.Name;
                            item.SizeGroupCode = dataSizeGroup?.Code;
                            item.SeasonName = dataSeason?.Name;
                            item.SeasonCode = dataSeason?.Code;
                            item.CropSeasonName = dataSeason?.Name;
                            item.CropSeasonCode = dataSeason?.Code;
                            item.MaterialTypeName = dataMaterialType?.Name;
                            item.MaterialTypeCode = dataMaterialType?.Code;
                            item.UomName = dataUom?.Name;
                            item.UomCode = dataUom?.Code;
                            item.StoringUomName = dataStoringUom?.Name;
                            item.StoringUomCode = dataStoringUom?.Code;
                            item.ConsUomName = dataConsUom?.Name;
                            item.ConsUomCode = dataConsUom?.Code;
                            item.DivisionName = dataDivision?.Name;
                            item.DivisionCode = dataDivision?.Code;
                            item.BuyingCurrencyName = dataCompanyCurrencies?.Name;
                            item.BuyingCurrencyCode = dataCompanyCurrencies?.Code;
                            item.PricePerName = dataPricePer?.Name;
                            item.PricePerCode = dataPricePer?.Code;
                            item.ProductCatName = productCategory?.Name;
                            item.ProductCatCode = productCategory?.Code;
                            item.ConstructionName = dataConstruction?.Name;
                            item.ConstructionCode = dataConstruction?.Code;
                            item.CountName = dataCount?.Name;
                            item.CountCode = dataCount?.Code;
                            var dicString = new Dictionary<string, string>();
                            dicString.Add(nameof(materialRequest.SpinningMethod), materialRequest.SpinningMethod);
                            dicString.Add(nameof(materialRequest.CountType), materialRequest.CountType);
                            dicString.Add(nameof(materialRequest.Certificate), materialRequest.Certificate);
                            dicString.Add(nameof(materialRequest.SpinningProcess), materialRequest.SpinningProcess);
                            dicString.Add(nameof(materialRequest.Pattern), materialRequest.Pattern);
                            dicString.Add(nameof(materialRequest.Twist), materialRequest.Twist);
                            var lstDataDynamicColumns = await _repositoryDynamicColumn.GetListByCodeAsync(dicString, MaterialRequestType.Yarns);
                            if (lstDataDynamicColumns.Count != dicString.Count(x => !string.IsNullOrEmpty(x.Value)))
                            {
                                return new Core.Models.Responses.Response<bool>(false, "Dynamic Column wrong format");
                            }
                            foreach (var dc in lstDataDynamicColumns)
                            {
                                item.DynamicColumns.Add(new MaterialRequestDynamicColumn
                                {
                                    Value = dicString.FirstOrDefault(x => x.Key == dc.Code).Value,
                                    DynamicColumnId = dc.Id
                                });
                            }
                            materialRequests.Add(item);
                        }
                        break;
                    }
                default:
                    return new Core.Models.Responses.Response<bool>(false);
            }
            return new Core.Models.Responses.Response<bool>(await _repository.AddMaterialRequestRangeAsync(materialRequests));
        }
    }
}