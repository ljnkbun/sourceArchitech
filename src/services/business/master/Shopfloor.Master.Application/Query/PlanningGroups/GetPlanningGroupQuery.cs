using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PlanningGroups
{
    public class GetPlanningGroupQuery : IRequest<Response<PlanningGroup>>
    {
        public int Id { get; set; }
    }
    public class GetPlanningGroupQueryHandler : IRequestHandler<GetPlanningGroupQuery, Response<PlanningGroup>>
    {
        private readonly IPlanningGroupRepository _repository;
        public GetPlanningGroupQueryHandler(IPlanningGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<PlanningGroup>> Handle(GetPlanningGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"PlanningGroup Not Found (Id:{query.Id}).");
            return new Response<PlanningGroup>(entity);
        }
    }
}
