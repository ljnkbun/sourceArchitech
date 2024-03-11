using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Helpers;
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
            var buyerTypeTask = _requestClientService.GetResponseAsync<GetBuyerTypesRequest, GetBuyerTypesResponse>(new GetBuyerTypesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);
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
                var dataFilterCountry = ObjectHelper.FindDataCodeName(countries?.Message?.Data, r.Country);
                var dataFilterCurrency = ObjectHelper.FindDataCodeName(companyCurrencies?.Message?.Data, r.Currency);
                var dataFilterGroupName = ObjectHelper.FindDataCodeName(groupName?.Message?.Data, r.GroupNameCode);
                var dataFilterCategory = ObjectHelper.FindDataCodeName(subCategories?.Message?.Data, r.Category);
                var dataFilterAccountGroup = ObjectHelper.FindDataCodeName(accountGroup?.Message?.Data, r.AccountGroup);
                var dataFilterBuyerType = ObjectHelper.FindDataCodeName(buyerType?.Message?.Data, r.BuyerType);

                ObjectHelper.SetDataProperties(x, dataFilterCategory, "CategoryCode", "CategoryName");
                ObjectHelper.SetDataProperties(x, dataFilterCountry, "CountryCode", "CountryName");
                ObjectHelper.SetDataProperties(x, dataFilterCurrency, "CurrencyCode", "CurrencyName");
                ObjectHelper.SetDataProperties(x, dataFilterGroupName, "GroupNameCode", "GroupName");
                ObjectHelper.SetDataProperties(x, dataFilterAccountGroup, "AccountGroupCode", "AccountGroupName");
                ObjectHelper.SetDataProperties(x, dataFilterBuyerType, "BuyerType", "BuyerTypeName");

                if (!string.IsNullOrEmpty(r.BusinessSegment))
                {
                    var buz = r.BusinessSegment.Split(',');
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

                if (!string.IsNullOrEmpty(r.ProductCategory) && categories is { Message.Data: not null })
                {
                    foreach (var c in r.ProductCategory.Split(','))
                    {
                        var category = categories.Message.Data?.FirstOrDefault(z => z.Name.Equals(c, StringComparison.OrdinalIgnoreCase));
                        if (category != null)
                        {
                            x.ProductCategories.Add(new BuyerProductCategory
                            {
                                CategoryCode = category.Code,
                                CategoryName = category.Name,
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