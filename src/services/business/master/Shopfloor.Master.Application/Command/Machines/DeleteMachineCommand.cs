using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Machines
{
    public class DeleteMachineCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMachineCommandHandler : IRequestHandler<DeleteMachineCommand, Response<int>>
    {
        private readonly IMachineRepository _repository;
        public DeleteMachineCommandHandler(IMachineRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMachineCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Machine Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
