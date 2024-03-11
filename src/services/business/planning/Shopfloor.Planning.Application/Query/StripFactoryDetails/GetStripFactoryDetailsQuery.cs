using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.StripFactoryDetails;
using Shopfloor.Planning.Application.Parameters.StripFactoryDetails;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripFactoryDetails
{
    public class GetStripFactoryDetailsQuery : IRequest<PagedResponse<IReadOnlyList<StripFactoryDetailModel>>>, ICacheableMediatrQuery
    {
        public int? PorDetailId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int? StripFactoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"StripFactoryDetails";
        public TimeSpan? SlidingExpiration { get; set; }
        public bool? IsAllocated { get; set; }
    }

    public class GetStripFactoryDetailsQueryHandler : IRequestHandler<GetStripFactoryDetailsQuery, PagedResponse<IReadOnlyList<StripFactoryDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryDetailRepository _repository;

        public GetStripFactoryDetailsQueryHandler(IMapper mapper,
            IStripFactoryDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<StripFactoryDetailModel>>> Handle(GetStripFactoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<StripFactoryDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<StripFactoryDetailParameter, StripFactoryDetailModel>(validFilter);
        }
    }
}
