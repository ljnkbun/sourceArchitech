using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.ZoneTypes
{
    public class DeleteZoneTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteZoneTypeCommandHandler : IRequestHandler<DeleteZoneTypeCommand, Response<int>>
    {
        private readonly IZoneTypeRepository _repository;
        public DeleteZoneTypeCommandHandler(IZoneTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteZoneTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"ZoneType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
