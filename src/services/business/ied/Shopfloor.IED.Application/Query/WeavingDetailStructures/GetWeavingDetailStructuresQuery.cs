using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingDetailStructures;
using Shopfloor.IED.Application.Parameters.WeavingDetailStructures;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingDetailStructures
{
    public class GetWeavingDetailStructuresQuery : IRequest<PagedResponse<IReadOnlyList<WeavingDetailStructureModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public StructureType? StructureType { get; set; }
        public int? CombString { get; set; }
        public int? SlotNumber { get; set; }
        public int? Total { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"WeavingDetailStructures";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingDetailStructuresQueryHandler : IRequestHandler<GetWeavingDetailStructuresQuery, PagedResponse<IReadOnlyList<WeavingDetailStructureModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingDetailStructureRepository _repository;
        public GetWeavingDetailStructuresQueryHandler(IMapper mapper,
            IWeavingDetailStructureRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingDetailStructureModel>>> Handle(GetWeavingDetailStructuresQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingDetailStructureParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingDetailStructureParameter, WeavingDetailStructureModel>(validFilter);
        }
    }
}
