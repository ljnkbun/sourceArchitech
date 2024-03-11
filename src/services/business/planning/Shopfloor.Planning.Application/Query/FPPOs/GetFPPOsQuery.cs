using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.FPPOs;
using Shopfloor.Planning.Application.Parameters.FPPOs;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.FPPOs
{
    public class GetFPPOsQuery : IRequest<PagedResponse<IReadOnlyList<FPPOModel>>>
    {
        public int? StripScheduleId { get; set; }
        public int? WFXFPPOId { get; set; }
        public string FPPONo { get; set; }
        public int? WFXOCId { get; set; }
        public string OCNo { get; set; }
        public string WFXDeliveryOrderCode { get; set; }
        public string Supplier { get; set; }
        public string WipDispatchSite { get; set; }
        public string WipReceivingSite { get; set; }
        public int? PORId { get; set; }
        public string PORNo { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public int? FactoryId { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string UOM { get; set; }
        public bool? WFXSynced { get; set; }
        public bool? Deleted { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWfxFPPOsQueryHandler : IRequestHandler<GetFPPOsQuery, PagedResponse<IReadOnlyList<FPPOModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPORepository _response;
        public GetWfxFPPOsQueryHandler(IMapper mapper
            , IFPPORepository response)
        {
            _mapper = mapper;
            _response = response;
        }

        public async Task<PagedResponse<IReadOnlyList<FPPOModel>>> Handle(GetFPPOsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FPPOParameter>(request);
            return await _response.GetModelPagedReponseAsync<FPPOParameter, FPPOModel>(validFilter);
        }
    }
}