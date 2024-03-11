using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.PlanningGroups;
using Shopfloor.Master.Application.Parameters.PlanningGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PlanningGroups
{
    public class GetPlanningGroupsQuery : IRequest<PagedResponse<IReadOnlyList<PlanningGroupModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ProcessId { get; set; }
        public int? CalendarId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"PlanningGroups";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPlanningGroupsQueryHandler : IRequestHandler<GetPlanningGroupsQuery, PagedResponse<IReadOnlyList<PlanningGroupModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPlanningGroupRepository _repository;
        public GetPlanningGroupsQueryHandler(IMapper mapper,
            IPlanningGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PlanningGroupModel>>> Handle(GetPlanningGroupsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PlanningGroupParameter>(request);
            return await _repository.GetPlanningGroupsModelAsync<PlanningGroupParameter, PlanningGroupModel>(validFilter);
        }
    }
}
