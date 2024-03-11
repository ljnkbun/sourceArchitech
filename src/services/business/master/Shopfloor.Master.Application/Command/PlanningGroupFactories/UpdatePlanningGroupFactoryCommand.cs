using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PlanningGroupFactories
{
    public class UpdatePlanningGroupFactoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdatePlanningGroupFactoryCommandHandler : IRequestHandler<UpdatePlanningGroupFactoryCommand, Response<int>>
    {
        private readonly IPlanningGroupFactoryRepository _repository;
        public UpdatePlanningGroupFactoryCommandHandler(IPlanningGroupFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdatePlanningGroupFactoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"PlanningGroupFactory Not Found.");

            entity.PlanningGroupId = command.PlanningGroupId;
            entity.FactoryId = command.FactoryId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
