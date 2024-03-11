using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PlanningGroupFactories
{
    public class DeletePlanningGroupFactoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePlanningGroupFactoryCommandHandler : IRequestHandler<DeletePlanningGroupFactoryCommand, Response<int>>
    {
        private readonly IPlanningGroupFactoryRepository _repository;
        public DeletePlanningGroupFactoryCommandHandler(IPlanningGroupFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeletePlanningGroupFactoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"PlanningGroupFactory Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
