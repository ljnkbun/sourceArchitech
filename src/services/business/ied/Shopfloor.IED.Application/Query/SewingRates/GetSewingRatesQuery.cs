using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRates;
using Shopfloor.IED.Application.Parameters.SewingRates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingRates
{
    public class GetSewingRatesQuery : IRequest<PagedResponse<IReadOnlyList<SewingRateModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public decimal? ExpectedQtyFrom { get; set; }
        public decimal? ExpectedQtyTo { get; set; }
        public decimal? EfficiencyRate { get; set; }
        public decimal? CMRate { get; set; }
        public string Description { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingRates";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingRatesQueryHandler : IRequestHandler<GetSewingRatesQuery, PagedResponse<IReadOnlyList<SewingRateModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingRateRepository _repository;
        public GetSewingRatesQueryHandler(IMapper mapper,
            ISewingRateRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingRateModel>>> Handle(GetSewingRatesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingRateParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingRateParameter, SewingRateModel>(validFilter);
        }
    }
}
