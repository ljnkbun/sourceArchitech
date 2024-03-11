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
using Shopfloor.Material.Application.Models.PriceLists;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.PriceLists
{
    public class ImportPriceListCommand : IRequest<Response<bool>>
    {
        public IFormFile File { get; set; }
    }

    public class ImportPriceListCommandHandler : IRequestHandler<ImportPriceListCommand, Response<bool>>
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

        public async Task<Response<bool>> Handle(ImportPriceListCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.PriceList);
            var data = ImportExcelHelper.ReadExcel<PriceListImportExcelModel>(request.File, input);
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
                var detail = new PriceListDetail
                {
                    ArticleCode = item.ArticleCode,
                    Currency = item.Currency,
                    Price = item.Price ?? 0,
                    ValidTo = item.ValidTo,
                    Uom = item.Uom,
                    DeliveryTerm = item.DeliveryTerm,
                    ValidFrom = item.ValidFrom,
                    PriceListDetailColors = new List<PriceListDetailColor>
                    {
                        new()
                        {
                            Code = item.ColorCode,
                            Name = item.ColorName
                        }
                    },
                    PriceListDetailSizes = sizes?.Message?.Data.Where(i => i.Code == item.SizeCode).Select(y => new PriceListDetailSize
                    {
                        Code = y.Code,
                        Name = y.Name
                    }).ToList()
                };
                x.Status = ProcessStatus.Draft;
                x.PriceListDetails.Add(detail);
                priceLists.Add(x);
            }
            return new Response<bool>(await _repository.AddPriceListRangeAsync(priceLists));
        }
    }
}