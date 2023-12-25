using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ShipmentTerms;
using Shopfloor.Master.Application.Parameters.ProductGroups;
using Shopfloor.Master.Application.Parameters.ShipmentTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ShipmentTerms
{
    public class GetShipmentTermsQuery : IRequest<PagedResponse<IReadOnlyList<ShipmentTermModel>>>, ICacheableMediatrQuery
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
        public string CacheKey => $"ShipmentTerms";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetShipmentTermsQueryHandler : IRequestHandler<GetShipmentTermsQuery, PagedResponse<IReadOnlyList<ShipmentTermModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IShipmentTermRepository _repository;
        public GetShipmentTermsQueryHandler(IMapper mapper,
            IShipmentTermRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ShipmentTermModel>>> Handle(GetShipmentTermsQuery request, CancellationToken cancellationToken)
        {

            var validFilter = _mapper.Map<ShipmentTermParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ShipmentTermParameter.Code), nameof(ShipmentTermParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ShipmentTermParameter, ShipmentTermModel>(validFilter);
        }
    }
}
