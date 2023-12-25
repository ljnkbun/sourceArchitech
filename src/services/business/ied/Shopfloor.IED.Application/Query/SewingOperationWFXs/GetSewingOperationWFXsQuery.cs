using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationWFXs;
using Shopfloor.IED.Application.Parameters.SewingOperationWFXs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationWFXs
{
    public class GetSewingOperationWFXsQuery : IRequest<PagedResponse<IReadOnlyList<SewingOperationWFXModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestDivisionProcessId { get; set; }
        public int? CurrentVersionId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string Buyer { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public Status? Status { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"SewingOperationWFXs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetSewingOperationWFXsQueryHandler : IRequestHandler<GetSewingOperationWFXsQuery, PagedResponse<IReadOnlyList<SewingOperationWFXModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationWFXRepository _repository;
        public GetSewingOperationWFXsQueryHandler(IMapper mapper,
            ISewingOperationWFXRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingOperationWFXModel>>> Handle(GetSewingOperationWFXsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingOperationWFXParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingOperationWFXParameter, SewingOperationWFXModel>(validFilter);
        }
    }
}
