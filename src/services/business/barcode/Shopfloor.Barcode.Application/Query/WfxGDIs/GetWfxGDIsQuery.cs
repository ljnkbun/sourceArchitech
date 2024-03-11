using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxGDIs;
using Shopfloor.Barcode.Application.Parameters.WfxGDIs;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxGDIs
{
    public class GetWfxGDIsQuery : IRequest<PagedResponse<IReadOnlyList<WfxGDIMasterModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string GDINum { get; set; }
        public ExportTypes? GDITypes { get; set; }
        public string GDIType { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public string OrderRefNum { get; set; }
        public string SupplierName { get; set; }
        public string WFXArticleCode { get; set; }
        public string WareHouse { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetWfxGDIEntitiesQueryHandler : IRequestHandler<GetWfxGDIsQuery, PagedResponse<IReadOnlyList<WfxGDIMasterModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDIRepository _repository;
        private readonly ILocationRepository _locationRepository;

        public GetWfxGDIEntitiesQueryHandler(IMapper mapper,
            IWfxGDIRepository repository
            , ILocationRepository locationRepository
            )
        {
            _mapper = mapper;
            _repository = repository;
            _locationRepository = locationRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxGDIMasterModel>>> Handle(GetWfxGDIsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxGDIParameter>(request);
            validFilter.GDIType = validFilter.GDITypes.ToString();

            var rs = await _repository.GetListAsync<WfxGDIParameter, WfxGDIMasterModel>(validFilter, validFilter.FromOrderDate, validFilter.ToOrderDate);

            var locs = await _locationRepository.GetAllAsync();

            if (rs.Data == null) return _mapper.Map<PagedResponse<IReadOnlyList<WfxGDIMasterModel>>>(rs);

            foreach (var item in rs.Data)
            {
                item.LocationId = locs.FirstOrDefault(x => x.Name == item.Location)?.Id;
            }
            return rs;
        }
    }
}
