using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Application.Parameters.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ArticleBarcodes
{
    public class GetMergeSplitByIdsQuery : IRequest<PagedResponse<IReadOnlyList<ArticleBarcodeHistoryModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string Ids { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ArticleBarcodeHistory";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetMergeSplitByIdsQueryHandler : IRequestHandler<GetMergeSplitByIdsQuery, PagedResponse<IReadOnlyList<ArticleBarcodeHistoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleBarcodeHistoryRepository _repository;

        public GetMergeSplitByIdsQueryHandler(IMapper mapper,
            IArticleBarcodeHistoryRepository repository
            )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ArticleBarcodeHistoryModel>>> Handle(GetMergeSplitByIdsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ArticleBarcodeHistoryParameter>(request);
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            return await _repository.GetModelPagedCustomReponseAsync<ArticleBarcodeHistoryParameter, ArticleBarcodeHistoryModel>(validFilter, validFilter.Ids);

        }
    }
}
