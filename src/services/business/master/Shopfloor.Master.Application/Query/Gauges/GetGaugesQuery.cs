using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Gauges;
using Shopfloor.Master.Application.Parameters.Staples;
using Shopfloor.Master.Application.Parameters.Gauges;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Gauges
{
    public class GetGaugesQuery : IRequest<PagedResponse<IReadOnlyList<GaugeModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"Gauges";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetGaugesQueryHandler : IRequestHandler<GetGaugesQuery, PagedResponse<IReadOnlyList<GaugeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IGaugeRepository _repository;
        public GetGaugesQueryHandler(IMapper mapper,
            IGaugeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<GaugeModel>>> Handle(GetGaugesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GaugeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(GaugeParameter.Code), nameof(GaugeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<GaugeParameter, GaugeModel>(validFilter);
        }
    }
}
