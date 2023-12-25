using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.ProcessTemplateItems;
using Shopfloor.IED.Application.Parameters.ProcessTemplateItems;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.ProcessTemplateItems
{
    public class GetProcessTemplateItemsQuery : IRequest<PagedResponse<IReadOnlyList<ProcessTemplateItemModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? ProcessTemplateId { get; set; }
        public string Division { get; set; }
        public int? Priority { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProcessTemplateItems";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetProcessTemplateItemsQueryHandler : IRequestHandler<GetProcessTemplateItemsQuery, PagedResponse<IReadOnlyList<ProcessTemplateItemModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessTemplateItemRepository _repository;
        public GetProcessTemplateItemsQueryHandler(IMapper mapper,
            IProcessTemplateItemRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProcessTemplateItemModel>>> Handle(GetProcessTemplateItemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProcessTemplateItemParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ProcessTemplateItemParameter, ProcessTemplateItemModel>(validFilter);
        }
    }
}
