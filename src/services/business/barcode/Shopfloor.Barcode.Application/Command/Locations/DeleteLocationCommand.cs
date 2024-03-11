using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Command.Locations
{
    public class DeleteLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Response<int>>
    {
        private readonly ILocationRepository _repository;
        public DeleteLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Location Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
