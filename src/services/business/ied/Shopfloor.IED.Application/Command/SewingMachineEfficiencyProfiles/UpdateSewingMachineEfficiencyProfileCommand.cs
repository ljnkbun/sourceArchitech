using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles
{
    public class UpdateSewingMachineEfficiencyProfileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int SewingEfficiencyProfileId { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateSewingMachineEfficiencyProfileCommandHandler : IRequestHandler<UpdateSewingMachineEfficiencyProfileCommand, Response<int>>
    {
        private readonly ISewingMachineEfficiencyProfileRepository _repository;

        public UpdateSewingMachineEfficiencyProfileCommandHandler(ISewingMachineEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateSewingMachineEfficiencyProfileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingMachineEfficiencyProfile Not Found.");

            entity.SewingEfficiencyProfileId = command.SewingEfficiencyProfileId;
            entity.MachineId = command.MachineId;
            entity.MachineName = command.MachineName;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}