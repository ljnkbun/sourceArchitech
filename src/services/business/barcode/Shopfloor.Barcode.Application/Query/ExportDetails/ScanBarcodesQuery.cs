using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ExportDetails
{
    public class ScanBarcodesQuery : IRequest<Response<ICollection<ExportDetail>>>
    {
        public string Barcodes { get; set; }
    }
    public class ScanBarcodesQueryHandler : IRequestHandler<ScanBarcodesQuery, Response<ICollection<ExportDetail>>>
    {
        private readonly IArticleBarcodeRepository _repository;
        private readonly IMapper _mapper;

        public ScanBarcodesQueryHandler(
            IArticleBarcodeRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ICollection<ExportDetail>>> Handle(ScanBarcodesQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Barcodes)) return new("Barcode not found.");
            var barcodes = await _repository.GetAllByBarcodesAsync(request.Barcodes.Split(',').Select(x => x.Trim()).ToArray());
            if (!(barcodes?.Any() ?? false)) return new("Barcode not found.");

            var exportDetails = _mapper.Map<List<ExportDetail>>(barcodes);
            foreach (var exportDetail in exportDetails)
            {
                var barcode = barcodes.FirstOrDefault(x => x.Barcode == exportDetail.Barcode);
                exportDetail.ArticleBarcode = barcode;
                exportDetail.ArticleBarcodeId = barcode.Id;
                exportDetail.LocationId = barcode.CurrentLocationId;
                exportDetail.Status = Domain.Constants.ItemStatus.PROCESSING;
            }


            return new Response<ICollection<ExportDetail>>(exportDetails);
        }
    }
}
