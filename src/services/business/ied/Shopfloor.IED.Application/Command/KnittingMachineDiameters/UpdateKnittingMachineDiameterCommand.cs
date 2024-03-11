using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingMachineDiameters
{
    public class UpdateKnittingMachineDiameterCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingMachineDiameterCommandHandler : IRequestHandler<UpdateKnittingMachineDiameterCommand, Response<int>>
    {
        private readonly IKnittingMachineDiameterRepository _repository;
        public UpdateKnittingMachineDiameterCommandHandler(IKnittingMachineDiameterRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingMachineDiameterCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingMachineDiameter Not Found.");

            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
