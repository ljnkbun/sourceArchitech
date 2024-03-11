using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.ZoneTypes;
using Shopfloor.Inspection.Application.Parameters.ZoneTypes;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.ZoneTypes
{
    public class GetZoneTypesQuery : IRequest<PagedResponse<IReadOnlyList<ZoneTypeModel>>>
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
    }
    public class GetZoneTypesQueryHandler : IRequestHandler<GetZoneTypesQuery, PagedResponse<IReadOnlyList<ZoneTypeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IZoneTypeRepository _repository;
        public GetZoneTypesQueryHandler(IMapper mapper,
            IZoneTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ZoneTypeModel>>> Handle(GetZoneTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ZoneTypeParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ZoneTypeParameter.Code), nameof(ZoneTypeParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ZoneTypeParameter, ZoneTypeModel>(validFilter);
        }
    }
}
