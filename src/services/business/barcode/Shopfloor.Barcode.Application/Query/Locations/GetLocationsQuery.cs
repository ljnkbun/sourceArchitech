using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Application.Models.Locations;
using Shopfloor.Barcode.Application.Parameters.Locations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Domain.Enums.LevelLocations;

namespace Shopfloor.Barcode.Application.Query.Locations
{
    public class GetLocationsQuery : IRequest<PagedResponse<IReadOnlyList<LocationModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentLocationId { get; set; }
        public string Barcode { get; set; }
        public LevelLocation? LevelLocation { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Location";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, PagedResponse<IReadOnlyList<LocationModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _repository;
        public GetLocationsQueryHandler(IMapper mapper,
            ILocationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LocationModel>>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LocationParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(LocationParameter.Code), nameof(LocationParameter.Name) 
                , nameof(LocationParameter.ParentLocationId) , nameof(LocationParameter.Barcode) , nameof(LocationParameter.LevelLocation) }.ToList());
            return await _repository.GetModelPagedReponseAsync<LocationParameter, LocationModel>(validFilter);
        }
    }
}
