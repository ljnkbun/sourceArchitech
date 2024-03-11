using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Application.Parameters.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetArticleBarcodesQuery : IRequest<PagedResponse<IReadOnlyList<ArticleBarcodeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string Barcode { get; set; }
        public string Barcodes { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleCodes { get; set; }
        public string PONo { get; set; }
        public string GDINum { get; set; }
        public string OrderRefNum { get; set; }
        public string FPPOOCNUm { get; set; }
        public string SupplierName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
        public string ArticleUOM { get; set; }
        public string BarcodeUOM { get; set; }
        public string Shade { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Site { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string GroupCode { get; set; }
        public string Note { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PreLocationId { get; set; }


        public decimal? Balance { get; set; }
        public decimal? FPPOQty { get; set; }
        public decimal? UpdatedToDate { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ArticleBarcode";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetArticleBarcodesQueryHandler : IRequestHandler<GetArticleBarcodesQuery, PagedResponse<IReadOnlyList<ArticleBarcodeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleBarcodeRepository _repository;
        public GetArticleBarcodesQueryHandler(IMapper mapper,
            IArticleBarcodeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ArticleBarcodeModel>>> Handle(GetArticleBarcodesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ArticleBarcodeParameter>(request);
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            var rs = await _repository.GetModelPagedCustomReponseAsync<ArticleBarcodeParameter, ArticleBarcodeModel>(validFilter, validFilter.Barcodes, validFilter.ArticleCodes);

            var barcodes = await _repository.GetByIdsAsync(rs.Data.SelectMany(x => x.FromId ?? Array.Empty<int>()).Concat(rs.Data.SelectMany(o => o.ToId ?? Array.Empty<int>())).ToList());

            foreach (var r in rs.Data)
            {
                r.FromBarcodes = barcodes.Where(x => (r.FromId ?? Array.Empty<int>()).Contains(x.Id)).Select(x => x?.Barcode)?.ToArray();
                if (!r.FromBarcodes.Any()) r.FromBarcodes = null;
                r.ToBarcodes = barcodes.Where(x => (r.ToId ?? Array.Empty<int>()).Contains(x.Id)).Select(x => x?.Barcode)?.ToArray();
                if (!r.ToBarcodes.Any()) r.ToBarcodes = null;
            }

            return rs;
        }
    }
}
