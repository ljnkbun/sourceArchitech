using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.Buyers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class ImportBuyerCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public IFormFile File { get; set; }
    }

    public class ImportBuyerCommandHandler : IRequestHandler<ImportBuyerCommand, Core.Models.Responses.Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IBuyerRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public ImportBuyerCommandHandler(IMapper mapper,
            IBuyerRepository repository,
            IRequestClientService requestClientService)
        {
            _mapper = mapper;
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<Core.Models.Responses.Response<bool>> Handle(ImportBuyerCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.Buyer);
            var data = ImportExcelHelper.ReadExcel<BuyerImportExcelModel>(request.File, input);
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
            var buyerTypeTask = _requestClientService.GetResponseAsync<GetBuyerTypesRequest, GetBuyerTypesResponse>(new GetBuyerTypesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            });
            tasks.Add(buyerTypeTask);

            await Task.WhenAll(tasks);
            var companyCurrencies = companyCurrenciesTask.Result;
            var categories = categoriesTask.Result;
            var countries = countriesTask.Result;
            var groupName = groupNameTask.Result;
            var subCategories = subCategoriesTask.Result;
            var accountGroup = accountGroupTask.Result;
            var buyerType = buyerTypeTask.Result;

            var buyers = new List<Buyer>();
            foreach (var r in data)
            {
                var x = _mapper.Map<Buyer>(r);
                x.ProductCategories = new List<BuyerProductCategory>();
                x.CountryName = countries?.Message?.Data?.FirstOrDefault(v => v.Name == r.Country?.Trim() || v.Code == r.Country?.Trim())?.Name;
                x.Country = countries?.Message?.Data?.FirstOrDefault(v => v.Name == r.Country?.Trim() || v.Code == r.Country?.Trim())?.Code;
                x.CurrencyName = companyCurrencies?.Message?.Data?.FirstOrDefault(v => v.Name == r.Currency?.Trim() || v.Code == r.Currency?.Trim())?.Name;
                x.Currency = companyCurrencies?.Message?.Data?.FirstOrDefault(v => v.Name == r.Currency?.Trim() || v.Code == r.Currency?.Trim())?.Code;
                x.GroupName = groupName?.Message?.Data?.FirstOrDefault(v => v.Name == r.GroupNameCode?.Trim() || v.Code == r.GroupNameCode?.Trim())?.Name;
                x.GroupNameCode = groupName?.Message?.Data?.FirstOrDefault(v => v.Name == r.GroupNameCode?.Trim() || v.Code == r.GroupNameCode?.Trim())?.Code;
                x.Category = subCategories?.Message?.Data?.FirstOrDefault(v => v.Name == r.Category?.Trim() || v.Code == r.Category?.Trim())?.Name;
                x.AccountGroupName = accountGroup?.Message?.Data?.FirstOrDefault(v => v.Name == r.AccountGroup?.Trim() || v.Code == r.AccountGroup?.Trim())?.Name;
                x.AccountGroup = accountGroup?.Message?.Data?.FirstOrDefault(v => v.Name == r.AccountGroup?.Trim() || v.Code == r.AccountGroup?.Trim())?.Code;
                x.BuyerTypeName = buyerType?.Message?.Data?.FirstOrDefault(v => v.Name == r.BuyerType?.Trim() || v.Code == r.BuyerType?.Trim())?.Name;
                x.BuyerType = buyerType?.Message?.Data?.FirstOrDefault(v => v.Name == r.BuyerType?.Trim() || v.Code == r.BuyerType?.Trim())?.Code;

                if (!string.IsNullOrEmpty(r.BusinessSegment))
                {
                    var buz = r.BusinessSegment.Split(',');
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
                if (!string.IsNullOrEmpty(r.ProductCategory) && categories != null && categories.Message.Data != null)
                {
                    var cats = r.ProductCategory.Split(',');
                    foreach (var c in cats)
                    {
                        var f = categories.Message.Data?.FirstOrDefault(x => x.Name.Equals(c, StringComparison.OrdinalIgnoreCase));
                        if (f != null)
                        {
                            x.ProductCategories.Add(new BuyerProductCategory
                            {
                                CategoryCode = f.Code,
                                CategoryName = f.Name,
                                IsActive = true
                            });
                        }
                    }
                }
                x.Status = ProcessStatus.Draft;
                buyers.Add(x);
            }
            return new Core.Models.Responses.Response<bool>(await _repository.AddBuyerRangeAsync(buyers));
        }
    }
}