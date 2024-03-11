using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.QCRequestArticles;
using Shopfloor.Inspection.Application.Parameters.QCRequestArticles;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCRequestArticles
{
    public class GetQCRequestArticlesQuery : IRequest<PagedResponse<IReadOnlyList<QCRequestArticleModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? QCRequestId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Shade { get; set; }
        public string Lot { get; set; }
        public string StyleNo { get; set; }
        public string StyleName { get; set; }
        public string Season { get; set; }
        public string Buyer { get; set; }
        public string FPONo { get; set; }
        public string Location { get; set; }
        public string UOM { get; set; }
        public string OCNo { get; set; }
        public string GRNNo { get; set; }
        public string PONo { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public decimal? QCReleasedQty { get; set; }
        public decimal? GRNQty { get; set; }
        public DateTime? GRNDate { get; set; }
        public decimal? RequestedQty { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public string JobOrderNo { get; set; }
        public string BatchNo { get; set; }
        public string Line { get; set; }
        public string Machine { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public decimal? WeightKg { get; set; }
        public decimal? WidghtKg { get; set; }
        public decimal? Length { get; set; }
        public decimal? RollQty { get; set; }
        public bool? IsActive { get; set; }
        public int? QCTypeId { get; set; }
        public string QCRequestNo { get; set; }
    }
    public class GetQCRequestArticlesQueryHandler : IRequestHandler<GetQCRequestArticlesQuery, PagedResponse<IReadOnlyList<QCRequestArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCRequestArticleRepository _repository;
        public GetQCRequestArticlesQueryHandler(IMapper mapper,
            IQCRequestArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCRequestArticleModel>>> Handle(GetQCRequestArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCRequestArticleParameter>(request);
            return await _repository.GetWithDetailPagedReponseAsync<QCRequestArticleParameter, QCRequestArticleModel>(validFilter, validFilter.QCTypeId, validFilter.QCRequestNo);
        }
    }
}
