using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SpinningProcesses
{
    public class DeleteSpinningProcessCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSpinningProcessCommandHandler : IRequestHandler<DeleteSpinningProcessCommand, Response<int>>
    {
        private readonly ISpinningProcessRepository _repository;
        public DeleteSpinningProcessCommandHandler(ISpinningProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSpinningProcessCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SpinningProcess Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
