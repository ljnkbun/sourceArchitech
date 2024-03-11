using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingMachineDiameters
{
    public class DeleteKnittingMachineDiameterCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteKnittingMachineDiameterCommandHandler : IRequestHandler<DeleteKnittingMachineDiameterCommand, Response<int>>
    {
        private readonly IKnittingMachineDiameterRepository _repository;
        public DeleteKnittingMachineDiameterCommandHandler(IKnittingMachineDiameterRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteKnittingMachineDiameterCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"KnittingMachineDiameter Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
