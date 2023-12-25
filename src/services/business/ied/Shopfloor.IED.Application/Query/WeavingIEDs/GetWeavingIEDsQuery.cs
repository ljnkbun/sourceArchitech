using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingIEDs;
using Shopfloor.IED.Application.Parameters.WeavingIEDs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingIEDs
{
    public class GetWeavingIEDsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingIEDModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestDivisionId { get; set; }
        public string RequestNo { get; set; }
        public string Comment { get; set; }
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
        public string CacheKey => $"WeavingIEDs";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingIEDsQueryHandler : IRequestHandler<GetWeavingIEDsQuery, PagedResponse<IReadOnlyList<WeavingIEDModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingIEDRepository _repository;
        public GetWeavingIEDsQueryHandler(IMapper mapper,
            IWeavingIEDRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingIEDModel>>> Handle(GetWeavingIEDsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingIEDParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingIEDParameter, WeavingIEDModel>(validFilter);
        }
    }
}
