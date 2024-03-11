using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.CriticalParts
{
    public class UpdateCriticalPartCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
		public int PlanningGroupId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int Priority { get; set; }
	}
    public class UpdateCriticalPartCommandHandler : IRequestHandler<UpdateCriticalPartCommand, Response<int>>
    {
        private readonly ICriticalPartRepository _repository;
        public UpdateCriticalPartCommandHandler(ICriticalPartRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateCriticalPartCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"CriticalPart Not Found.");

            entity.PlanningGroupId = command.PlanningGroupId;
            entity.Name = command.Name;
            entity.Color = command.Color;
            entity.Priority = command.Priority;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
