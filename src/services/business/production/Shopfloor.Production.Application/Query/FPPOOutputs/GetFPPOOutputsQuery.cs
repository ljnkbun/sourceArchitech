using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.FPPOOutputs;
using Shopfloor.Production.Application.Parameters.FPPOOutputs;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.FPPOOutputs
{
    public class GetFPPOOutputsQuery : IRequest<PagedResponse<IReadOnlyList<FPPOOutputModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? WFXArticleId { get; set; }
        public int? FPPOId { get; set; }
        public string FPPONo { get; set; }
        public string OCNo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public int? PORId { get; set; }
        public string PORNo { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public int? OperationId { get; set; }
        public string OperationCode { get; set; }
        public string OperationName { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public int? QCDefinationId { get; set; }
        public string QCName { get; set; }
        public string UOM { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetFPPOOutputsQueryHandler : IRequestHandler<GetFPPOOutputsQuery, PagedResponse<IReadOnlyList<FPPOOutputModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPOOutputRepository _repository;
        public GetFPPOOutputsQueryHandler(IMapper mapper,
            IFPPOOutputRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FPPOOutputModel>>> Handle(GetFPPOOutputsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FPPOOutputParameter>(request);
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            return await _repository.GetModelPagedReponseAsync<FPPOOutputParameter, FPPOOutputModel>(validFilter);
        }
    }
}
