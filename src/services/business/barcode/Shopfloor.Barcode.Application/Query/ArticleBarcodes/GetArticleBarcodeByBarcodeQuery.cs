using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodeByBarcodeQuery : IRequest<Response<ArticleBarcodeModel>>
    {
        public string Barcode { get; set; }
    }
    public class GetArticleBarcodeByBarcodeQueryHandler : IRequestHandler<GetArticleBarcodeByBarcodeQuery, Response<ArticleBarcodeModel>>
    {
        private readonly IArticleBarcodeRepository _repository;
        private readonly IMapper _mapper;

        public GetArticleBarcodeByBarcodeQueryHandler(IArticleBarcodeRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<ArticleBarcodeModel>> Handle(GetArticleBarcodeByBarcodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByBarcodeAsync(query.Barcode);
            if (entity == null) return new($"ArticleBarcodes Not Found (Barcode:{query.Barcode}).");

            var rs = _mapper.Map<ArticleBarcodeModel>(entity);
            var barcodes = await _repository.GetByIdsAsync((rs.FromId ?? Array.Empty<int>()).Concat(rs.ToId ?? Array.Empty<int>()).ToList());

            rs.FromBarcodes = barcodes.Where(x => (rs.FromId ?? Array.Empty<int>()).Contains(x.Id)).Select(x => x?.Barcode)?.ToArray();
            if (!rs.FromBarcodes.Any()) rs.FromBarcodes = null;
            rs.ToBarcodes = barcodes.Where(x => (rs.ToId ?? Array.Empty<int>()).Contains(x.Id)).Select(x => x?.Barcode)?.ToArray();
            if (!rs.ToBarcodes.Any()) rs.ToBarcodes = null;

            return new Response<ArticleBarcodeModel>(rs);
        }
    }
}
