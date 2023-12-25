using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXs;
using Shopfloor.IED.Application.Parameters.SewingSubOperationWFXs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingSubOperationWFXs
{
    public class GetSewingSubOperationWFXsQuery : IRequest<PagedResponse<IReadOnlyList<SewingSubOperationWFXModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestDivisionProcessId { get; set; }
        public int? CurrentVersionId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string LineNumber { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalSMV { get; set; }
        public decimal? NonMachineTime { get; set; }
        public decimal? LabourCost { get; set; }
        public string QuatityPoints { get; set; }
        public string QualityComments { get; set; }
        public string Freq { get; set; }
        public decimal? Effort { get; set; }
        public decimal? AllowedTime { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingSubOperationWFXs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingSubOperationWFXsQueryHandler : IRequestHandler<GetSewingSubOperationWFXsQuery, PagedResponse<IReadOnlyList<SewingSubOperationWFXModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingSubOperationWFXRepository _repository;
        public GetSewingSubOperationWFXsQueryHandler(IMapper mapper,
            ISewingSubOperationWFXRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingSubOperationWFXModel>>> Handle(GetSewingSubOperationWFXsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingSubOperationWFXParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingSubOperationWFXParameter, SewingSubOperationWFXModel>(validFilter);
        }
    }
}
