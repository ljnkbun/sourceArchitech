using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ExportDetails
{
    public class ScanBarcodeQuery : IRequest<Response<ExportDetail>>
    {
        public string Barcode { get; set; }
    }
    public class ScanBarcodeQueryHandler : IRequestHandler<ScanBarcodeQuery, Response<ExportDetail>>
    {
        private readonly IArticleBarcodeRepository _repository;
        private readonly IMapper _mapper;

        public ScanBarcodeQueryHandler(
            IArticleBarcodeRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ExportDetail>> Handle(ScanBarcodeQuery request, CancellationToken cancellationToken)
        {
            var barcode = await _repository.GetByBarcodeAsync(request.Barcode);
            if (barcode == null) return new("Barcode not found.");

            var exportDetail = _mapper.Map<ExportDetail>(barcode);
            exportDetail.ArticleBarcode = barcode;
            exportDetail.ArticleBarcodeId = barcode.Id;
            exportDetail.LocationId = barcode.CurrentLocationId;
            exportDetail.Status = Domain.Constants.ItemStatus.PROCESSING;

            return new Response<ExportDetail>(exportDetail);
        }
    }
}
