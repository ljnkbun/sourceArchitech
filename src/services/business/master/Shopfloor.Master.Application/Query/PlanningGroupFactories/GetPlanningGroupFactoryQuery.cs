using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PlanningGroupFactories
{
    public class GetPlanningGroupFactoryQuery : IRequest<Response<PlanningGroupFactory>>
    {
        public int Id { get; set; }
    }
    public class GetPlanningGroupFactoryQueryHandler : IRequestHandler<GetPlanningGroupFactoryQuery, Response<PlanningGroupFactory>>
    {
        private readonly IPlanningGroupFactoryRepository _repository;
        public GetPlanningGroupFactoryQueryHandler(IPlanningGroupFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<PlanningGroupFactory>> Handle(GetPlanningGroupFactoryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"PlanningGroupFactory Not Found (Id:{query.Id}).");
            return new Response<PlanningGroupFactory>(entity);
        }
    }
}
