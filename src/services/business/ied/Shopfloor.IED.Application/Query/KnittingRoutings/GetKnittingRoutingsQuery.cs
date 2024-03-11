using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingRoutings;
using Shopfloor.IED.Application.Parameters.KnittingRoutings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingRoutings
{
    public class GetKnittingRoutingsQuery : IRequest<PagedResponse<IReadOnlyList<KnittingRoutingModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? KnittingIEDId { get; set; }
        public string KnittingProcessCode { get; set; }
        public string KnittingOperationCode { get; set; }
        public int? LineNumber { get; set; }
        public string KnittingProcess { get; set; }
        public string KnittingOperation { get; set; }
        public int? MachineTypeId { get; set; }
        public string MachineTypeName { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetKnittingRoutingsQueryHandler : IRequestHandler<GetKnittingRoutingsQuery, PagedResponse<IReadOnlyList<KnittingRoutingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingRoutingRepository _repository;
        public GetKnittingRoutingsQueryHandler(IMapper mapper,
            IKnittingRoutingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingRoutingModel>>> Handle(GetKnittingRoutingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingRoutingParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingRoutingParameter, KnittingRoutingModel>(validFilter);
        }
    }
}
