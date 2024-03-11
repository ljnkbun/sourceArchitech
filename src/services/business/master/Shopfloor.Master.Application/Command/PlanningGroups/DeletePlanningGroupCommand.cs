using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PlanningGroups
{
    public class DeletePlanningGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePlanningGroupCommandHandler : IRequestHandler<DeletePlanningGroupCommand, Response<int>>
    {
        private readonly IPlanningGroupRepository _repository;
        public DeletePlanningGroupCommandHandler(IPlanningGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeletePlanningGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"PlanningGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
