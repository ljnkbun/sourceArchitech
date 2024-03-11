using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Zones
{
    public class DeleteZoneCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand, Response<int>>
    {
        private readonly IZoneRepository _repository;
        public DeleteZoneCommandHandler(IZoneRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteZoneCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Zone Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
