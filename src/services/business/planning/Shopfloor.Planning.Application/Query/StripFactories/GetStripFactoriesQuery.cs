using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.StripFactories;
using Shopfloor.Planning.Application.Parameters.StripFactories;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripFactories
{
    public class GetStripFactoriesQuery : IRequest<PagedResponse<IReadOnlyList<StripFactoryModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? PlanningGroupFactoryId { get; set; }
        public int? ProcessId { get; set; }
        public int? PORId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainningQuantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsPlanning { get; set; }
        public bool? IsAllocated { get; set; }
        public bool? IsSplitBatch { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public string JobOrderNo { get; set; }
        public string BatchNo { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetStripFactorysQueryHandler : IRequestHandler<GetStripFactoriesQuery, PagedResponse<IReadOnlyList<StripFactoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryRepository _repository;
        public GetStripFactorysQueryHandler(IMapper mapper,
            IStripFactoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripFactoryModel>>> Handle(GetStripFactoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripFactoryParameter>(request);
            return await _repository.GetStripFactoryModelPagedReponseAsync<StripFactoryParameter, StripFactoryModel>(
                validFilter, 
                request.ProcessId,
                request.ArticleName,
                request.ArticleCode,
                request.Buyer,
                request.Category,
                request.SubCategory,
                request.ProductGroup,
                request.JobOrderNo,
                request.BatchNo);
        }
    }
}
