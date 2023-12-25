using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXResults;
using Shopfloor.IED.Application.Parameters.SewingSubOperationWFXResults;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingSubOperationWFXResults
{
    public class GetSewingSubOperationWFXResultsQuery : IRequest<PagedResponse<IReadOnlyList<GetSewingSubOperationWFXResultModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? SewingSubOperationWFXId { get; set; }
        public TMUType? TMUType { get; set; }
        public decimal? TMU { get; set; }
        public decimal? BasicMunite { get; set; }
        public decimal? PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal? Total { get; set; }
        public decimal? Contingency { get; set; }
        public decimal? SMV { get; set; }
        public decimal? Cost { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingSubOperationWFXResults";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingSubOperationWFXResultsQueryHandler : IRequestHandler<GetSewingSubOperationWFXResultsQuery, PagedResponse<IReadOnlyList<GetSewingSubOperationWFXResultModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingSubOperationWFXResultRepository _repository;
        public GetSewingSubOperationWFXResultsQueryHandler(IMapper mapper,
            ISewingSubOperationWFXResultRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<GetSewingSubOperationWFXResultModel>>> Handle(GetSewingSubOperationWFXResultsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingSubOperationWFXResultParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingSubOperationWFXResultParameter, GetSewingSubOperationWFXResultModel>(validFilter);
        }
    }
}
