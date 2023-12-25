using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.Suppliers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Suppliers
{
    public class ImportSupplierCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public IFormFile File { get; set; }
    }

    public class
        ImportSupplierCommandHandler : IRequestHandler<ImportSupplierCommand, Core.Models.Responses.Response<bool>>
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

        public async Task<Core.Models.Responses.Response<bool>> Handle(ImportSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.Supplier);
            var data = ImportExcelHelper.ReadExcel<SupplierImportExcelModel>(request.File, input);
            if (data == null || data.Count == 0)
                return new Core.Models.Responses.Response<bool>(false, "No data import");
            var tasks = new List<Task>();

            var countriesTask = _requestClientService.GetResponseAsync<GetCountriesRequest, GetCountriesResponse>(new GetCountriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(countriesTask);
            var companyCurrenciesTask = _requestClientService.GetResponseAsync<GetCompanyCurrenciesRequest, GetCompanyCurrenciesResponse>(new GetCompanyCurrenciesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(companyCurrenciesTask);

            var categoriesTask = _requestClientService.GetResponseAsync<GetCategoriesRequest, GetCategoriesResponse>(new GetCategoriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(categoriesTask);
            var groupNameTask = _requestClientService.GetResponseAsync<GetGroupNamesRequest, GetGroupNamesResponse>(new GetGroupNamesRequest()
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(groupNameTask);
            var subCategoriesTask = _requestClientService.GetResponseAsync<GetSubCategoriesRequest, GetSubCategoriesResponse>(new GetSubCategoriesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(subCategoriesTask);
            var accountGroupTask = _requestClientService.GetResponseAsync<GetAccountGroupsRequest, GetAccountGroupsResponse>(new GetAccountGroupsRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(accountGroupTask);
            var supplierTypeTask = _requestClientService.GetResponseAsync<GetSupplierTypesRequest, GetSupplierTypesResponse>(new GetSupplierTypesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
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

                x.CountryCode = countries.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.CountryName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.CountryName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Code;

                x.CountryName = countries.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.CountryName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.CountryName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Name;

                x.CurrencyCode = companyCurrencies.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.CurrencyName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.CurrencyName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Code;

                x.CurrencyName = companyCurrencies.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.CurrencyName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.CurrencyName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Name;

                x.GroupNameCode = groupName.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.GroupName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.GroupName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Code;

                x.GroupName = groupName.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.GroupName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.GroupName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Name;

                x.CategoryCode = subCategories.Message.Data?.FirstOrDefault(i => i.Name.Equals(x.CategoryName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(x.CategoryName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Code;

                x.CategoryName = subCategories.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.CategoryName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.CategoryName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Name;

                x.AccountGroupCode = accountGroup.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.AccountGroupName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.AccountGroupName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Code;

                x.AccountGroupName = accountGroup.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.AccountGroupName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.AccountGroupName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Name;

                x.SupplierTypeCode = supplierType.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.SupplierTypeName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.SupplierTypeName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Code;

                x.SupplierTypeName = supplierType.Message.Data?.FirstOrDefault(i => i.Name.Equals(item.SupplierTypeName?.Trim(), StringComparison.OrdinalIgnoreCase) || i.Code.Equals(item.SupplierTypeName?.Trim(), StringComparison.OrdinalIgnoreCase))?.Name;

                x.Status = ProcessStatus.Draft;

                if (!string.IsNullOrEmpty(item.BusinessSegment))
                {
                    var buz = item.BusinessSegment.Split(',');
                    x.IsRetailer = buz.Any(v => v.Equals("retailer", StringComparison.OrdinalIgnoreCase));
                    x.IsServiceProvider = buz.Any(v => v.Equals("serviceprovider", StringComparison.OrdinalIgnoreCase));
                    x.IsWholesaler = buz.Any(v => v.Equals("wholesaler", StringComparison.OrdinalIgnoreCase));
                    x.IsManufacture = buz.Any(v => v.Equals("manufacturer", StringComparison.OrdinalIgnoreCase));
                    x.IsTransporter = buz.Any(v => v.Equals("transporter", StringComparison.OrdinalIgnoreCase));
                    x.IsComposition = buz.Any(v => v.Equals("composition dealer", StringComparison.OrdinalIgnoreCase));
                    x.IsBuying = buz.Any(v => v.StartsWith("buying", StringComparison.OrdinalIgnoreCase));
                    x.IsBrand = buz.Any(v => v.Equals("brand", StringComparison.OrdinalIgnoreCase));
                    x.IsOther = buz.Any(v => v.Equals("other", StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(item.ProductCategory) && categories.Message.Data != null)
                {
                    var cats = item.ProductCategory.Split(',');
                    foreach (var c in cats)
                    {
                        var f = categories.Message.Data?.FirstOrDefault(i => i.Name.Equals(c, StringComparison.OrdinalIgnoreCase));
                        if (f != null)
                        {
                            x.SupplierProductCategories.Add(new SupplierProductCategory
                            {
                                Code = f.Code,
                                Name = f.Name
                            });
                        }
                    }
                }
                suppliers.Add(x);
            }
            return new Core.Models.Responses.Response<bool>(await _repository.AddSupplierRangeAsync(suppliers));
        }
    }
}