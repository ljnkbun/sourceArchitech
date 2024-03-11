using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.PlanningGroupFactories;
using Shopfloor.Master.Application.Parameters.PlanningGroupFactories;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PlanningGroupFactories
{
    public class GetPlanningGroupFactoriesQuery : IRequest<PagedResponse<IReadOnlyList<PlanningGroupFactoryModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? PlanningGroupId { get; set; }
        public int? FactoryId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"PlanningGroupFactories";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetPlanningGroupFactoriesQueryHandler : IRequestHandler<GetPlanningGroupFactoriesQuery, PagedResponse<IReadOnlyList<PlanningGroupFactoryModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IPlanningGroupFactoryRepository _repository;
        public GetPlanningGroupFactoriesQueryHandler(IMapper mapper,
            IPlanningGroupFactoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<PlanningGroupFactoryModel>>> Handle(GetPlanningGroupFactoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<PlanningGroupFactoryParameter>(request);
            return await _repository.GetModelPagedReponseAsync<PlanningGroupFactoryParameter, PlanningGroupFactoryModel>(validFilter);
        }
    }
}
