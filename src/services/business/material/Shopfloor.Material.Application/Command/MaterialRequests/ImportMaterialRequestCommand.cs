using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Requests.Divisions;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Divisions;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Helpers;
using Shopfloor.Material.Application.Models.MaterialRequests;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class ImportMaterialRequestCommand : IRequest<Response<bool>>
    {
        public IFormFile File { get; set; }

        public string Type { get; set; }
    }

    public class ImportMaterialRequestCommandHandler : IRequestHandler<ImportMaterialRequestCommand, Response<bool>>
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

        public async Task<Response<bool>> Handle(ImportMaterialRequestCommand request, CancellationToken cancellationToken)
        {
            ImportExcelModel input;
            var materialRequests = new List<MaterialRequest>();
            var productCategories = await _requestClientService.GetResponseAsync<GetCategoriesRequest, GetCategoriesResponse>(new GetCategoriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue,
                Code = request.Type.ToUpper()
            }, cancellationToken);
            var productCategory = productCategories?.Message.Data.FirstOrDefault();
            if (productCategory == null)
            {
                return new Response<bool>(false, "Product Category Not Found");
            }
            switch (request.Type)
            {
                case MaterialRequestType.Trims:
                    {
                        input = new ImportExcelModel(0, 2, FieldMaps.TrimsRequest);
                        var data = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(request.File, input);
                        if (data == null || data.Count == 0)
                        {
                            return new Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(subCategoriesTask);

                        var colorDefinitionTask = _requestClientService.GetResponseAsync<GetColorDefinitionsRequest, GetColorDefinitionsResponse>(new GetColorDefinitionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(colorDefinitionTask);

                        var colorCardTask = _requestClientService.GetResponseAsync<GetColorCardsRequest, GetColorCardsResponse>(new GetColorCardsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(colorCardTask);

                        var sizeGroupTask = _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(sizeGroupTask);

                        var seasonTask = _requestClientService.GetResponseAsync<GetCropSeasonsRequest, GetCropSeasonsResponse>(new GetCropSeasonsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(seasonTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(materialTypeTask);

                        var divisionTask = _requestClientService.GetResponseAsync<GetDivisionsRequest, GetDivisionsResponse>(new GetDivisionsRequest()
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(divisionTask);

                        var pricePerTask = _requestClientService.GetResponseAsync<GetPricePersRequest, GetPricePersResponse>(new GetPricePersRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(pricePerTask);

                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
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
                            var dataProductGroup = ObjectHelper.FindDataCodeName(productGroup?.Message?.Data, materialRequest.ProductGroupCode);
                            var dataProductSubCat = ObjectHelper.FindDataCodeName(subCategories?.Message?.Data, materialRequest.ProductSubCatCode);
                            var dataColorType = ObjectHelper.FindDataCodeName(colorDefinition?.Message?.Data, materialRequest.ColorTypeCode);
                            var dataColorGroup = ObjectHelper.FindDataCodeName(colorCard?.Message?.Data, materialRequest.ColorGroupCode);
                            var dataSizeGroup = ObjectHelper.FindDataCodeName(sizeGroup?.Message?.Data, materialRequest.SizeGroupCode);
                            var dataSeason = ObjectHelper.FindDataCodeName(season?.Message?.Data, materialRequest.SeasonCode);
                            var dataMaterialType = ObjectHelper.FindDataCodeName(materialType?.Message?.Data, materialRequest.MaterialTypeCode);
                            var dataUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.UomCode);
                            var dataStoringUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.StoringUomCode);
                            var dataConsUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.ConsUomCode);
                            var dataDivision = ObjectHelper.FindDataCodeName(division?.Message?.Data, materialRequest.DivisionCode);
                            var dataCompanyCurrencies = ObjectHelper.FindDataCodeName(companyCurrencies?.Message?.Data, materialRequest.BuyingCurrencyCode);
                            var dataPricePer = ObjectHelper.FindDataCodeName(pricePer?.Message?.Data, materialRequest.PricePerCode);
                            var dicRequiredString = new Dictionary<string, object>
                            {
                                { nameof(dataPricePer), dataPricePer },
                                { nameof(dataCompanyCurrencies), dataCompanyCurrencies },
                                { nameof(dataDivision), dataDivision },
                                { nameof(dataConsUom), dataConsUom },
                                { nameof(dataStoringUom), dataStoringUom },
                                { nameof(dataUom), dataUom },
                                { nameof(dataMaterialType), dataMaterialType },
                                { nameof(dataSeason), dataSeason },
                                { nameof(dataSizeGroup), dataSizeGroup },
                                { nameof(dataColorGroup), dataColorGroup },
                                { nameof(dataColorType), dataColorType },
                                { nameof(dataProductSubCat), dataProductSubCat },
                                { nameof(dataProductGroup), dataProductGroup }
                            };
                            var dicRequiredStringMessenger = new Dictionary<string, string>
                            {
                                { nameof(dataPricePer), "Price Per -Article" },
                                { nameof(dataCompanyCurrencies), "Selling Price-Currency" },
                                { nameof(dataDivision), "Company Division" },
                                { nameof(dataConsUom), "Consumption UOM" },
                                { nameof(dataStoringUom), "Storage UOM" },
                                { nameof(dataUom), "Purchase UOM" },
                                { nameof(dataMaterialType), "Material Type" },
                                { nameof(dataSeason), "Season" },
                                { nameof(dataSizeGroup), "Size Range" },
                                { nameof(dataColorGroup), "Color Card" },
                                { nameof(dataColorType), "Color Definition" },
                                { nameof(dataProductSubCat), "Sub Category" },
                                { nameof(dataProductGroup), "Product Group" }
                            };
                            var checkData = CheckRequiredData(dicRequiredString, dicRequiredStringMessenger);
                            if (!checkData.Data)
                            {
                                return checkData;
                            }
                            ObjectHelper.SetDataProperties(item, dataProductGroup, "ProductGroupCode", "ProductGroupName");
                            ObjectHelper.SetDataProperties(item, dataProductSubCat, "ProductSubCatCode", "ProductSubCatName");
                            ObjectHelper.SetDataProperties(item, dataColorType, "ColorTypeCode", "ColorTypeName");
                            ObjectHelper.SetDataProperties(item, dataColorGroup, "ColorGroupCode", "ColorGroupName");
                            ObjectHelper.SetDataProperties(item, dataSizeGroup, "SizeGroupCode", "SizeGroupName");
                            ObjectHelper.SetDataProperties(item, dataSeason, "SeasonCode", "SeasonName");
                            ObjectHelper.SetDataProperties(item, dataSeason, "CropSeasonCode", "CropSeasonName");
                            ObjectHelper.SetDataProperties(item, dataMaterialType, "MaterialTypeCode", "MaterialTypeName");
                            ObjectHelper.SetDataProperties(item, dataUom, "UomCode", "UomName");
                            ObjectHelper.SetDataProperties(item, dataStoringUom, "StoringUomCode", "StoringUomName");
                            ObjectHelper.SetDataProperties(item, dataConsUom, "ConsUomCode", "ConsUomName");
                            ObjectHelper.SetDataProperties(item, dataDivision, "DivisionCode", "DivisionName");
                            ObjectHelper.SetDataProperties(item, dataCompanyCurrencies, "BuyingCurrencyCode", "BuyingCurrencyName");
                            ObjectHelper.SetDataProperties(item, dataPricePer, "PricePerCode", "PricePerName");
                            ObjectHelper.SetDataProperties(item, productCategory, "ProductCatCode", "ProductCatName");
                            var dicString = new Dictionary<string, string>
                            {
                                { nameof(materialRequest.ButtonType), materialRequest.ButtonType },
                                { nameof(materialRequest.ButtonHole), materialRequest.ButtonHole },
                                { nameof(materialRequest.ElasticType), materialRequest.ElasticType },
                                { nameof(materialRequest.RivetType), materialRequest.RivetType },
                                { nameof(materialRequest.ZipperType), materialRequest.ZipperType },
                                { nameof(materialRequest.Layer), materialRequest.Layer },
                                { nameof(materialRequest.Brand), materialRequest.Brand },
                                { nameof(materialRequest.Tex), materialRequest.Tex }
                            };
                            var lstDataDynamicColumns = await _repositoryDynamicColumn.GetListByCodeAsync(dicString, MaterialRequestType.Trims);
                            if (lstDataDynamicColumns.Count != dicString.Count(x => !string.IsNullOrEmpty(x.Value)))
                            {
                                return new Response<bool>(false, "Dynamic Column wrong format");
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
                            return new Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(subCategoriesTask);

                        var colorDefinitionTask = _requestClientService.GetResponseAsync<GetColorDefinitionsRequest, GetColorDefinitionsResponse>(new GetColorDefinitionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(colorDefinitionTask);

                        var colorCardTask = _requestClientService.GetResponseAsync<GetColorCardsRequest, GetColorCardsResponse>(new GetColorCardsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(colorCardTask);

                        var sizeGroupTask = _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(sizeGroupTask);

                        var seasonTask = _requestClientService.GetResponseAsync<GetCropSeasonsRequest, GetCropSeasonsResponse>(new GetCropSeasonsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(seasonTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(materialTypeTask);

                        var countTask = _requestClientService.GetResponseAsync<GetCountsRequest, GetCountsResponse>(new GetCountsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(countTask);

                        var fabricTask = _requestClientService.GetResponseAsync<GetFabricContentsRequest, GetFabricContentsResponse>(new GetFabricContentsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(fabricTask);

                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(companyCurrenciesTask);

                        var constructionTask = _requestClientService.GetResponseAsync<GetConstructionsRequest, GetConstructionsResponse>(new GetConstructionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(constructionTask);

                        var divisionTask = _requestClientService.GetResponseAsync<GetDivisionsRequest, GetDivisionsResponse>(new GetDivisionsRequest()
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(divisionTask);

                        var pricePerTask = _requestClientService.GetResponseAsync<GetPricePersRequest, GetPricePersResponse>(new GetPricePersRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
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
                            var dataProductGroup = ObjectHelper.FindDataCodeName(productGroup?.Message?.Data, materialRequest.ProductGroupCode);
                            var dataProductSubCat = ObjectHelper.FindDataCodeName(subCategories?.Message?.Data, materialRequest.ProductSubCatCode);
                            var dataColorType = ObjectHelper.FindDataCodeName(colorDefinition?.Message?.Data, materialRequest.ColorTypeCode);
                            var dataColorGroup = ObjectHelper.FindDataCodeName(colorCard?.Message?.Data, materialRequest.ColorGroupCode);
                            var dataSizeGroup = ObjectHelper.FindDataCodeName(sizeGroup?.Message?.Data, materialRequest.SizeGroupCode);
                            var dataSeason = ObjectHelper.FindDataCodeName(season?.Message?.Data, materialRequest.SeasonCode);
                            var dataMaterialType = ObjectHelper.FindDataCodeName(materialType?.Message?.Data, materialRequest.MaterialTypeCode);
                            var dataUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.UomCode);
                            var dataStoringUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.StoringUomCode);
                            var dataConsUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.ConsUomCode);
                            var dataDivision = ObjectHelper.FindDataCodeName(division?.Message?.Data, materialRequest.DivisionCode);
                            var dataCompanyCurrencies = ObjectHelper.FindDataCodeName(companyCurrencies?.Message?.Data, materialRequest.BuyingCurrencyCode);
                            var dataPricePer = ObjectHelper.FindDataCodeName(pricePer?.Message?.Data, materialRequest.PricePerCode);
                            var dataConstruction = ObjectHelper.FindDataCodeName(construction?.Message?.Data, materialRequest.ConstructionCode);
                            var dataCount = ObjectHelper.FindDataCodeName(count?.Message?.Data, materialRequest.CountCode);
                            var dicRequiredString = new Dictionary<string, object>
                            {
                                { nameof(dataPricePer), dataPricePer },
                                { nameof(dataCompanyCurrencies), dataCompanyCurrencies },
                                { nameof(dataDivision), dataDivision },
                                { nameof(dataConsUom), dataConsUom },
                                { nameof(dataStoringUom), dataStoringUom },
                                { nameof(dataUom), dataUom },
                                { nameof(dataMaterialType), dataMaterialType },
                                { nameof(dataSeason), dataSeason },
                                { nameof(dataSizeGroup), dataSizeGroup },
                                { nameof(dataColorGroup), dataColorGroup },
                                { nameof(dataColorType), dataColorType },
                                { nameof(dataProductSubCat), dataProductSubCat },
                                { nameof(dataProductGroup), dataProductGroup },
                                { nameof(dataConstruction), dataConstruction },
                                { nameof(dataCount), dataCount }
                            };
                            var dicRequiredStringMessenger = new Dictionary<string, string>
                            {
                                { nameof(dataPricePer), "Price Per -Article" },
                                { nameof(dataCompanyCurrencies), "Buying Price-Currency" },
                                { nameof(dataDivision), "Company Division" },
                                { nameof(dataConsUom), "Consumption UOM" },
                                { nameof(dataStoringUom), "Storage UOM" },
                                { nameof(dataUom), "Purchase UOM" },
                                { nameof(dataMaterialType), "Material Type" },
                                { nameof(dataSeason), "Season" },
                                { nameof(dataSizeGroup), "Size Range" },
                                { nameof(dataColorGroup), "Color Card" },
                                { nameof(dataColorType), "Color Definition" },
                                { nameof(dataProductSubCat), "Sub Category" },
                                { nameof(dataProductGroup), "Product Group" },
                                { nameof(dataConstruction), "Construction" },
                                { nameof(dataCount), "Count" }
                            };
                            var checkData = CheckRequiredData(dicRequiredString, dicRequiredStringMessenger);
                            if (!checkData.Data)
                            {
                                return checkData;
                            }
                            if (!string.IsNullOrEmpty(materialRequest.FabricComposition) && fabric is { Message.Data: not null })
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
                                            return new Response<bool>(false, "Fabric Composition Not Found");
                                        }
                                    }
                                }
                            }
                            ObjectHelper.SetDataProperties(item, dataProductGroup, "ProductGroupCode", "ProductGroupName");
                            ObjectHelper.SetDataProperties(item, dataProductSubCat, "ProductSubCatCode", "ProductSubCatName");
                            ObjectHelper.SetDataProperties(item, dataColorType, "ColorTypeCode", "ColorTypeName");
                            ObjectHelper.SetDataProperties(item, dataColorGroup, "ColorGroupCode", "ColorGroupName");
                            ObjectHelper.SetDataProperties(item, dataSizeGroup, "SizeGroupCode", "SizeGroupName");
                            ObjectHelper.SetDataProperties(item, dataSeason, "SeasonCode", "SeasonName");
                            ObjectHelper.SetDataProperties(item, dataSeason, "CropSeasonCode", "CropSeasonName");
                            ObjectHelper.SetDataProperties(item, dataMaterialType, "MaterialTypeCode", "MaterialTypeName");
                            ObjectHelper.SetDataProperties(item, dataUom, "UomCode", "UomName");
                            ObjectHelper.SetDataProperties(item, dataStoringUom, "StoringUomCode", "StoringUomName");
                            ObjectHelper.SetDataProperties(item, dataConsUom, "ConsUomCode", "ConsUomName");
                            ObjectHelper.SetDataProperties(item, dataDivision, "DivisionCode", "DivisionName");
                            ObjectHelper.SetDataProperties(item, dataCompanyCurrencies, "BuyingCurrencyCode", "BuyingCurrencyName");
                            ObjectHelper.SetDataProperties(item, dataPricePer, "PricePerCode", "PricePerName");
                            ObjectHelper.SetDataProperties(item, productCategory, "ProductCatCode", "ProductCatName");
                            ObjectHelper.SetDataProperties(item, dataConstruction, "ConstructionCode", "ConstructionName");
                            ObjectHelper.SetDataProperties(item, dataCount, "CountCode", "CountName");
                            var dicString = new Dictionary<string, string>
                            {
                                { nameof(materialRequest.TCFNO), materialRequest.TCFNO },
                                { nameof(materialRequest.GSM), materialRequest.GSM },
                                { nameof(materialRequest.NoOfEnds), materialRequest.NoOfEnds },
                                { nameof(materialRequest.SpinningMethod), materialRequest.SpinningMethod },
                                { nameof(materialRequest.Certificate), materialRequest.Certificate },
                                { nameof(materialRequest.Gauge), materialRequest.Gauge },
                                { nameof(materialRequest.StitchLength), materialRequest.StitchLength },
                                { nameof(materialRequest.YarnComposition), materialRequest.YarnComposition },
                                { nameof(materialRequest.CutWidth), materialRequest.CutWidth },
                                { nameof(materialRequest.Structure), materialRequest.Structure }
                            };
                            var lstDataDynamicColumns = await _repositoryDynamicColumn.GetListByCodeAsync(dicString, MaterialRequestType.Fabric);
                            if (lstDataDynamicColumns.Count != dicString.Count(x => !string.IsNullOrEmpty(x.Value)))
                            {
                                return new Response<bool>(false, "Dynamic Column wrong format");
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
                            return new Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(subCategoriesTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(materialTypeTask);

                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
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

                            var dataProductGroup = ObjectHelper.FindDataCodeName(productGroup?.Message?.Data, materialRequest.ProductGroupCode);
                            var dataProductSubCat = ObjectHelper.FindDataCodeName(subCategories?.Message?.Data, materialRequest.ProductSubCatCode);
                            var dataMaterialType = ObjectHelper.FindDataCodeName(materialType?.Message?.Data, materialRequest.MaterialTypeCode);
                            var dataUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.UomCode);
                            var dataStoringUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.StoringUomCode);
                            var dataCompanyCurrencies = ObjectHelper.FindDataCodeName(companyCurrencies?.Message?.Data, materialRequest.BuyingCurrencyCode);
                            var dicRequiredString = new Dictionary<string, object>
                            {
                                { nameof(dataCompanyCurrencies), dataCompanyCurrencies },
                                { nameof(dataStoringUom), dataStoringUom },
                                { nameof(dataUom), dataUom },
                                { nameof(dataMaterialType), dataMaterialType },
                                { nameof(dataProductSubCat), dataProductSubCat },
                                { nameof(dataProductGroup), dataProductGroup }
                            };

                            var dicRequiredStringMessenger = new Dictionary<string, string>
                            {
                                { nameof(dataCompanyCurrencies), "Buying Price-Currency" },
                                { nameof(dataStoringUom), "Storage UOM" },
                                { nameof(dataUom), "Purchase UOM" },
                                { nameof(dataMaterialType), "Material Type" },
                                { nameof(dataProductSubCat), "Sub Category" },
                                { nameof(dataProductGroup), "Product Group" }
                            };
                            var checkData = CheckRequiredData(dicRequiredString, dicRequiredStringMessenger);
                            if (!checkData.Data)
                            {
                                return checkData;
                            }
                            ObjectHelper.SetDataProperties(item, dataProductGroup, "ProductGroupCode", "ProductGroupName");
                            ObjectHelper.SetDataProperties(item, dataProductSubCat, "ProductSubCatCode", "ProductSubCatName");
                            ObjectHelper.SetDataProperties(item, dataMaterialType, "MaterialTypeCode", "MaterialTypeName");
                            ObjectHelper.SetDataProperties(item, dataUom, "UomCode", "UomName");
                            ObjectHelper.SetDataProperties(item, dataStoringUom, "StoringUomCode", "StoringUomName");
                            ObjectHelper.SetDataProperties(item, dataCompanyCurrencies, "BuyingCurrencyCode", "BuyingCurrencyName");
                            ObjectHelper.SetDataProperties(item, productCategory, "ProductCatCode", "ProductCatName");
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
                            return new Response<bool>(false, "No data import");
                        }

                        var tasks = new List<Task>();
                        var productGroupTask = _requestClientService.GetResponseAsync<GetProductGroupsRequest, GetProductGroupsResponse>(new GetProductGroupsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(productGroupTask);

                        var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(subCategoriesTask);

                        var colorDefinitionTask = _requestClientService.GetResponseAsync<GetColorDefinitionsRequest, GetColorDefinitionsResponse>(new GetColorDefinitionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(colorDefinitionTask);

                        var colorCardTask = _requestClientService.GetResponseAsync<GetColorCardsRequest, GetColorCardsResponse>(new GetColorCardsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(colorCardTask);

                        var sizeGroupTask = _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(sizeGroupTask);

                        var seasonTask = _requestClientService.GetResponseAsync<GetCropSeasonsRequest, GetCropSeasonsResponse>(new GetCropSeasonsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(seasonTask);

                        var uomTask = _requestClientService.GetResponseAsync<GetUOMsRequest, GetUOMsResponse>(new GetUOMsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(uomTask);

                        var materialTypeTask = _requestClientService.GetResponseAsync<GetMaterialTypesRequest, GetMaterialTypesResponse>(new GetMaterialTypesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(materialTypeTask);

                        var countTask = _requestClientService.GetResponseAsync<GetCountsRequest, GetCountsResponse>(new GetCountsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(countTask);
                        var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(companyCurrenciesTask);

                        var constructionTask = _requestClientService.GetResponseAsync<GetConstructionsRequest, GetConstructionsResponse>(new GetConstructionsRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(constructionTask);

                        var divisionTask = _requestClientService.GetResponseAsync<GetDivisionsRequest, GetDivisionsResponse>(new GetDivisionsRequest()
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
                        tasks.Add(divisionTask);

                        var pricePerTask = _requestClientService.GetResponseAsync<GetPricePersRequest, GetPricePersResponse>(new GetPricePersRequest
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        }, cancellationToken);
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
                            var dataProductGroup = ObjectHelper.FindDataCodeName(productGroup?.Message?.Data, materialRequest.ProductGroupCode);
                            var dataProductSubCat = ObjectHelper.FindDataCodeName(subCategories?.Message?.Data, materialRequest.ProductSubCatCode);
                            var dataColorType = ObjectHelper.FindDataCodeName(colorDefinition?.Message?.Data, materialRequest.ColorTypeCode);
                            var dataColorGroup = ObjectHelper.FindDataCodeName(colorCard?.Message?.Data, materialRequest.ColorGroupCode);
                            var dataSizeGroup = ObjectHelper.FindDataCodeName(sizeGroup?.Message?.Data, materialRequest.SizeGroupCode);
                            var dataSeason = ObjectHelper.FindDataCodeName(season?.Message?.Data, materialRequest.SeasonCode);
                            var dataMaterialType = ObjectHelper.FindDataCodeName(materialType?.Message?.Data, materialRequest.MaterialTypeCode);
                            var dataUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.UomCode);
                            var dataStoringUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.StoringUomCode);
                            var dataConsUom = ObjectHelper.FindDataCodeName(uom?.Message?.Data, materialRequest.ConsUomCode);
                            var dataDivision = ObjectHelper.FindDataCodeName(division?.Message?.Data, materialRequest.DivisionCode);
                            var dataCompanyCurrencies = ObjectHelper.FindDataCodeName(companyCurrencies?.Message?.Data, materialRequest.BuyingCurrencyCode);
                            var dataPricePer = ObjectHelper.FindDataCodeName(pricePer?.Message?.Data, materialRequest.PricePerCode);
                            var dataConstruction = ObjectHelper.FindDataCodeName(construction?.Message?.Data, materialRequest.ConstructionCode);
                            var dataCount = ObjectHelper.FindDataCodeName(count?.Message?.Data, materialRequest.CountCode);
                            var dicRequiredString = new Dictionary<string, object>
                            {
                                { nameof(dataPricePer), dataPricePer },
                                { nameof(dataCompanyCurrencies), dataCompanyCurrencies },
                                { nameof(dataDivision), dataDivision },
                                { nameof(dataConsUom), dataConsUom },
                                { nameof(dataStoringUom), dataStoringUom },
                                { nameof(dataUom), dataUom },
                                { nameof(dataMaterialType), dataMaterialType },
                                { nameof(dataSeason), dataSeason },
                                { nameof(dataSizeGroup), dataSizeGroup },
                                { nameof(dataColorGroup), dataColorGroup },
                                { nameof(dataColorType), dataColorType },
                                { nameof(dataProductSubCat), dataProductSubCat },
                                { nameof(dataProductGroup), dataProductGroup },
                                { nameof(dataConstruction), dataConstruction },
                                { nameof(dataCount), dataCount }
                            };

                            var dicRequiredStringMessenger = new Dictionary<string, string>
                            {
                                { nameof(dataPricePer), "Price Per -Article" },
                                { nameof(dataCompanyCurrencies), "Buying Price-Currency" },
                                { nameof(dataDivision), "Company Division" },
                                { nameof(dataConsUom), "Consumption UOM" },
                                { nameof(dataStoringUom), "Storage UOM" },
                                { nameof(dataUom), "Purchase UOM" },
                                { nameof(dataMaterialType), "Material Type" },
                                { nameof(dataSeason), "Season" },
                                { nameof(dataSizeGroup), "Size Range" },
                                { nameof(dataColorGroup), "Color Card" },
                                { nameof(dataColorType), "Color Definition" },
                                { nameof(dataProductSubCat), "Sub Category" },
                                { nameof(dataProductGroup), "Product Group" },
                                { nameof(dataConstruction), "Construction" },
                                { nameof(dataCount), "Count" }
                            };
                            var checkData = CheckRequiredData(dicRequiredString, dicRequiredStringMessenger);
                            if (!checkData.Data)
                            {
                                return checkData;
                            }
                            ObjectHelper.SetDataProperties(item, dataProductGroup, "ProductGroupCode", "ProductGroupName");
                            ObjectHelper.SetDataProperties(item, dataProductSubCat, "ProductSubCatCode", "ProductSubCatName");
                            ObjectHelper.SetDataProperties(item, dataColorType, "ColorTypeCode", "ColorTypeName");
                            ObjectHelper.SetDataProperties(item, dataColorGroup, "ColorGroupCode", "ColorGroupName");
                            ObjectHelper.SetDataProperties(item, dataSizeGroup, "SizeGroupCode", "SizeGroupName");
                            ObjectHelper.SetDataProperties(item, dataSeason, "SeasonCode", "SeasonName");
                            ObjectHelper.SetDataProperties(item, dataSeason, "CropSeasonCode", "CropSeasonName");
                            ObjectHelper.SetDataProperties(item, dataMaterialType, "MaterialTypeCode", "MaterialTypeName");
                            ObjectHelper.SetDataProperties(item, dataUom, "UomCode", "UomName");
                            ObjectHelper.SetDataProperties(item, dataStoringUom, "StoringUomCode", "StoringUomName");
                            ObjectHelper.SetDataProperties(item, dataConsUom, "ConsUomCode", "ConsUomName");
                            ObjectHelper.SetDataProperties(item, dataDivision, "DivisionCode", "DivisionName");
                            ObjectHelper.SetDataProperties(item, dataCompanyCurrencies, "BuyingCurrencyCode", "BuyingCurrencyName");
                            ObjectHelper.SetDataProperties(item, dataPricePer, "PricePerCode", "PricePerName");
                            ObjectHelper.SetDataProperties(item, productCategory, "ProductCatCode", "ProductCatName");
                            ObjectHelper.SetDataProperties(item, dataConstruction, "ConstructionCode", "ConstructionName");
                            ObjectHelper.SetDataProperties(item, dataCount, "CountCode", "CountName");
                            var dicString = new Dictionary<string, string>
                            {
                                { nameof(materialRequest.SpinningMethod), materialRequest.SpinningMethod },
                                { nameof(materialRequest.CountType), materialRequest.CountType },
                                { nameof(materialRequest.Certificate), materialRequest.Certificate },
                                { nameof(materialRequest.SpinningProcess), materialRequest.SpinningProcess },
                                { nameof(materialRequest.Pattern), materialRequest.Pattern },
                                { nameof(materialRequest.Twist), materialRequest.Twist }
                            };
                            var lstDataDynamicColumns = await _repositoryDynamicColumn.GetListByCodeAsync(dicString, MaterialRequestType.Yarns);
                            if (lstDataDynamicColumns.Count != dicString.Count(x => !string.IsNullOrEmpty(x.Value)))
                            {
                                return new Response<bool>(false, "Dynamic Column wrong format");
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
                    return new Response<bool>(false);
            }
            return new Response<bool>(await _repository.AddMaterialRequestRangeAsync(materialRequests));
        }

        private Response<bool> CheckRequiredData(Dictionary<string, object> requiredProperties, Dictionary<string, string> requiredPropertyMessengers)
        {
            var requiredPropertyNames = requiredProperties.Keys.ToArray();

            foreach (var propertyName in requiredPropertyNames)
            {
                var propertyValue = requiredProperties[propertyName];

                if (propertyValue == default)
                {
                    return new Response<bool>(false, $"{requiredPropertyMessengers[propertyName]} Not Found");
                }
            }

            return new Response<bool>(true);
        }
    }
}