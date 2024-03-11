using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRoutings;
using Shopfloor.IED.Application.Parameters.SewingRoutings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingRoutings
{
    public class GetSewingRoutingsQuery : IRequest<PagedResponse<IReadOnlyList<SewingRoutingModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? SewingIEDId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string WFXOperationCode { get; set; }
        public string WFXOperationName { get; set; }
        public int? LineNumber { get; set; }
        public decimal? SMV { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetSewingRoutingsQueryHandler : IRequestHandler<GetSewingRoutingsQuery, PagedResponse<IReadOnlyList<SewingRoutingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingRoutingRepository _repository;
        public GetSewingRoutingsQueryHandler(IMapper mapper,
            ISewingRoutingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingRoutingModel>>> Handle(GetSewingRoutingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingRoutingParameter>(request);
            var result = await _repository.GetModelPagedReponseAsync<SewingRoutingParameter, SewingRoutingModel>(validFilter);
            result.Data = result.Data.OrderBy(r => r.LineNumber).ToList();
            return result;
        }
    }
}
