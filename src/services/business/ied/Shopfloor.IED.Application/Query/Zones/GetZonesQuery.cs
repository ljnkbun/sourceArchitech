using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Zones;
using Shopfloor.IED.Application.Parameters.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Zones
{
    public class GetZonesQuery : IRequest<PagedResponse<IReadOnlyList<ZoneModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? ZoneSalary { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Zones";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetZonesQueryHandler : IRequestHandler<GetZonesQuery, PagedResponse<IReadOnlyList<ZoneModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IZoneRepository _repository;
        public GetZonesQueryHandler(IMapper mapper,
            IZoneRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ZoneModel>>> Handle(GetZonesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ZoneParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ZoneParameter.Code), nameof(ZoneParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ZoneParameter, ZoneModel>(validFilter);
        }
    }
}
