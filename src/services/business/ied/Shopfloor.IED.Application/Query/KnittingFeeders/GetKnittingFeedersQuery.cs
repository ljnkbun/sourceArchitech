using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingFeeders;
using Shopfloor.IED.Application.Parameters.KnittingFeeders;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingFeeders
{
    public class GetKnittingFeedersQuery : IRequest<PagedResponse<IReadOnlyList<KnittingFeederModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"KnittingFeeders";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetKnittingFeedersQueryHandler : IRequestHandler<GetKnittingFeedersQuery, PagedResponse<IReadOnlyList<KnittingFeederModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingFeederRepository _repository;
        public GetKnittingFeedersQueryHandler(IMapper mapper,
            IKnittingFeederRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingFeederModel>>> Handle(GetKnittingFeedersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingFeederParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingFeederParameter, KnittingFeederModel>(validFilter);
        }
    }
}
