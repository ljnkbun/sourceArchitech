using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.PriceLists;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.PriceLists
{
    public class ImportPriceListCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public IFormFile File { get; set; }
    }

    public class ImportPriceListCommandHandler : IRequestHandler<ImportPriceListCommand, Core.Models.Responses.Response<bool>>
    {
        private readonly IPriceListRepository _repository;

        private readonly IRequestClientService _requestClientService;

        private readonly IMapper _mapper;

        public ImportPriceListCommandHandler(IPriceListRepository repository,
            IMapper mapper, IRequestClientService requestClientService)
        {
            _repository = repository;
            _mapper = mapper;
            _requestClientService = requestClientService;
        }

        public async Task<Core.Models.Responses.Response<bool>> Handle(ImportPriceListCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.PriceList);
            var data = ImportExcelHelper.ReadExcel<PriceListImportExcelModel>(request.File, input);
            if (data == null || data.Count == 0)
                return new Core.Models.Responses.Response<bool>(false, "No data import");

            var sizes = await _requestClientService.GetResponseAsync<GetSizeOrWidthRangesRequest, GetSizeOrWidthRangesResponse>(new GetSizeOrWidthRangesRequest
            {
                PageNumber = 1,
                PageSize = int.MaxValue
            }, cancellationToken);

            var priceLists = new List<PriceList>();
            foreach (var item in data)
            {
                var x = _mapper.Map<PriceList>(item);
                x.SupplierName = item.SupplierCode;
                var detail = new PriceListDetail();
                detail.ArticleCode = item.ArticleCode;
                detail.Currency = item.Currency;
                detail.Price = item.Price ?? 0;
                detail.ValidTo = item.ValidTo;
                detail.Uom = item.Uom;
                detail.DeliveryTerm = item.DeliveryTerm;
                detail.ValidFrom = item.ValidFrom;
                detail.PriceListDetailColors = new List<PriceListDetailColor>
                {
                    new()
                    {
                        Code = item.ColorCode,
                        Name = item.ColorName
                    }
                };
                detail.PriceListDetailSizes = sizes?.Message?.Data.Where(i => i.Code == item.SizeCode).Select(y => new PriceListDetailSize
                {
                    Code = y.Code,
                    Name = y.Name
                }).ToList();
                x.Status = ProcessStatus.Draft;
                x.PriceListDetails.Add(detail);
                priceLists.Add(x);
            }
            return new Core.Models.Responses.Response<bool>(await _repository.AddPriceListRangeAsync(priceLists));
        }
    }
}