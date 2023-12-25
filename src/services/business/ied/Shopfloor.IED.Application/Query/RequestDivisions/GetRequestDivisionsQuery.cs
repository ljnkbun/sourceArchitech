using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RequestDivisions;
using Shopfloor.IED.Application.Parameters.RequestDivisions;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestDivisions
{
    public class GetRequestDivisionsQuery : IRequest<PagedResponse<IReadOnlyList<RequestDivisionModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestId { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public int? LineNumber { get; set; }
        public int? Status { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"RequestDivisions";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetRequestDivisionsQueryHandler : IRequestHandler<GetRequestDivisionsQuery, PagedResponse<IReadOnlyList<RequestDivisionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestDivisionRepository _repository;
        public GetRequestDivisionsQueryHandler(IMapper mapper,
            IRequestDivisionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestDivisionModel>>> Handle(GetRequestDivisionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestDivisionParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestDivisionParameter, RequestDivisionModel>(validFilter);
        }
    }
}
