using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Helpers;
using Shopfloor.Material.Application.Models.Suppliers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class ImportSupplierCommand : IRequest<Response<bool>>
    {
        public IFormFile File { get; set; }
    }

    public class
        ImportSupplierCommandHandler : IRequestHandler<ImportSupplierCommand, Response<bool>>
    {
        private readonly ISupplierRepository _repository;

        private readonly IRequestClientService _requestClientService;

        private readonly IMapper _mapper;

        public ImportSupplierCommandHandler(ISupplierRepository repository, IMapper mapper, IRequestClientService requestClientService)
        {
            _repository = repository;
            _mapper = mapper;
            _requestClientService = requestClientService;
        }

        public async Task<Response<bool>> Handle(ImportSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.Supplier);
            var data = ImportExcelHelper.ReadExcel<SupplierImportExcelModel>(request.File, input);
            var tasks = new List<Task>();
            var countriesTask = _requestClientService.GetResponseAsync<GetCountriesRequest, GetCountriesResponse>(new GetCountriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(countriesTask);
            var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(companyCurrenciesTask);

            var categoriesTask = _requestClientService.GetResponseAsync<GetCategoriesRequest, GetCategoriesResponse>(new GetCategoriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(categoriesTask);
            var groupNameTask = _requestClientService.GetResponseAsync<GetGroupNamesRequest, GetGroupNamesResponse>(new GetGroupNamesRequest()
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(groupNameTask);
            var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(subCategoriesTask);
            var accountGroupTask = _requestClientService.GetResponseAsync<GetAccountGroupsRequest, GetAccountGroupsResponse>(new GetAccountGroupsRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(accountGroupTask);
            var supplierTypeTask = _requestClientService.GetResponseAsync<GetSupplierTypesRequest, GetSupplierTypesResponse>(new GetSupplierTypesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
            tasks.Add(supplierTypeTask);

            await Task.WhenAll(tasks);
            var companyCurrencies = companyCurrenciesTask.Result;
            var categories = categoriesTask.Result;
            var countries = countriesTask.Result;
            var groupName = groupNameTask.Result;
            var subCategories = subCategoriesTask.Result;
            var accountGroup = accountGroupTask.Result;
            var supplierType = supplierTypeTask.Result;
            var suppliers = new List<Supplier>();

            foreach (var item in data)
            {
                var x = _mapper.Map<Supplier>(item);
                x.SupplierProductCategories = new List<SupplierProductCategory>();
                var dataFilterCountry = ObjectHelper.FindDataCodeName(countries?.Message?.Data, item.CountryName);
                var dataFilterCurrency = ObjectHelper.FindDataCodeName(companyCurrencies?.Message?.Data, item.CurrencyName);
                var dataFilterGroupName = ObjectHelper.FindDataCodeName(groupName?.Message?.Data, item.GroupName);
                var dataFilterCategory = ObjectHelper.FindDataCodeName(subCategories?.Message?.Data, item.CategoryName);
                var dataFilterAccountGroup = ObjectHelper.FindDataCodeName(accountGroup?.Message?.Data, item.AccountGroupName);
                var dataFilterSupplierType = ObjectHelper.FindDataCodeName(supplierType?.Message?.Data, item.SupplierTypeName);
                ObjectHelper.SetDataProperties(x, dataFilterCategory, "CategoryCode", "CategoryName");
                ObjectHelper.SetDataProperties(x, dataFilterCountry, "CountryCode", "CountryName");
                ObjectHelper.SetDataProperties(x, dataFilterCurrency, "CurrencyCode", "CurrencyName");
                ObjectHelper.SetDataProperties(x, dataFilterGroupName, "GroupNameCode", "GroupName");
                ObjectHelper.SetDataProperties(x, dataFilterAccountGroup, "AccountGroupCode", "AccountGroupName");
                ObjectHelper.SetDataProperties(x, dataFilterSupplierType, "SupplierTypeCode", "SupplierTypeName");
                x.Status = ProcessStatus.Draft;

                if (!string.IsNullOrEmpty(item.BusinessSegment))
                {
                    var buz = item.BusinessSegment.Split(',');
                    var businessSegmentSet = new HashSet<string>(buz, StringComparer.OrdinalIgnoreCase);
                    x.IsRetailer = businessSegmentSet.Contains("retailer");
                    x.IsServiceProvider = businessSegmentSet.Contains("serviceprovider");
                    x.IsWholesaler = businessSegmentSet.Contains("wholesaler");
                    x.IsManufacture = businessSegmentSet.Contains("manufacturer");
                    x.IsTransporter = businessSegmentSet.Contains("transporter");
                    x.IsComposition = businessSegmentSet.Contains("composition dealer");
                    x.IsBuying = businessSegmentSet.Any(v => v.StartsWith("buying"));
                    x.IsBrand = businessSegmentSet.Contains("brand");
                    x.IsOther = businessSegmentSet.Contains("other");
                }

                if (!string.IsNullOrEmpty(item.ProductCategory) && categories is { Message.Data: not null })
                {
                    foreach (var c in item.ProductCategory.Split(','))
                    {
                        var category = categories.Message.Data?.FirstOrDefault(i => i.Name.Equals(c, StringComparison.OrdinalIgnoreCase));
                        if (category != null)
                        {
                            x.SupplierProductCategories.Add(new SupplierProductCategory
                            {
                                Code = category.Code,
                                Name = category.Name
                            });
                        }
                    }
                }
                suppliers.Add(x);
            }
            return new Response<bool>(await _repository.AddSupplierRangeAsync(suppliers));
        }
    }
}