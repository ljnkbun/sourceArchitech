using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles
{
    public class DeleteSewingMachineEfficiencyProfileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSewingMachineEfficiencyProfileCommandHandler : IRequestHandler<DeleteSewingMachineEfficiencyProfileCommand, Response<int>>
    {
        private readonly ISewingMachineEfficiencyProfileRepository _repository;

        public DeleteSewingMachineEfficiencyProfileCommandHandler(ISewingMachineEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteSewingMachineEfficiencyProfileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingMachineEfficiencyProfile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}