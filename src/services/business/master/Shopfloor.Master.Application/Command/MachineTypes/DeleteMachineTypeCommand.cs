using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MachineTypes
{
    public class DeleteMachineTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMachineTypeCommandHandler : IRequestHandler<DeleteMachineTypeCommand, Response<int>>
    {
        private readonly IMachineTypeRepository _repository;
        public DeleteMachineTypeCommandHandler(IMachineTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMachineTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"MachineType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
