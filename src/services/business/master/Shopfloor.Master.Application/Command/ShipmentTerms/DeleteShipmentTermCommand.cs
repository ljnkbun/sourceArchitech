using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ShipmentTerms
{
    public class DeleteShipmentTermCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteShipmentTermCommandHandler : IRequestHandler<DeleteShipmentTermCommand, Response<int>>
    {
        private readonly IShipmentTermRepository _repository;
        public DeleteShipmentTermCommandHandler(IShipmentTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteShipmentTermCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ShipmentTerm Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
