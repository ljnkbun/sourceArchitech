using MediatR;
using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Locations
{
    public class UpdateLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentLocationId { get; set; }
        public LevelLocation? LevelLocation { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Response<int>>
    {
        private readonly ILocationRepository _repository;
        public UpdateLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Location Not Found.");

            entity.Name = command.Name;
            entity.ParentLocationId = command.ParentLocationId;
            entity.LevelLocation = command.LevelLocation;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
