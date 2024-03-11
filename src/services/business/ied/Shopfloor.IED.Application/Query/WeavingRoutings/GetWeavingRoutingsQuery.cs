using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingRoutings;
using Shopfloor.IED.Application.Parameters.WeavingRoutings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRoutings
{
    public class GetWeavingRoutingsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingRoutingModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingProcessCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetWeavingRoutingsQueryHandler : IRequestHandler<GetWeavingRoutingsQuery, PagedResponse<IReadOnlyList<WeavingRoutingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRoutingRepository _repository;

        public GetWeavingRoutingsQueryHandler(IMapper mapper,
            IWeavingRoutingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingRoutingModel>>> Handle(GetWeavingRoutingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingRoutingParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingRoutingParameter, WeavingRoutingModel>(validFilter);
        }
    }
}