using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodeQuery : IRequest<Response<ArticleBarcodeModel>>
    {
        public int Id { get; set; }
    }
    public class GetArticleBarcodeQueryHandler : IRequestHandler<GetArticleBarcodeQuery, Response<ArticleBarcodeModel>>
    {
        private readonly IArticleBarcodeRepository _repository;
        private readonly IMapper _mapper;

        public GetArticleBarcodeQueryHandler(IArticleBarcodeRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<ArticleBarcodeModel>> Handle(GetArticleBarcodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ArticleBarcodes Not Found (Id:{query.Id}).");
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
