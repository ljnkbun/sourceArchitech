using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Domain.Enums.LevelLocations;

namespace Shopfloor.Barcode.Application.Command.Locations
{
    public class UpdateLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ParentLocationId { get; set; }
        public string Barcode { get; set; }
        public LevelLocation LevelLocation { get; set; }
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

            if (entity == null) throw new ApiException($"Location Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.ParentLocationId = command.ParentLocationId;
            entity.Barcode = command.Barcode;
            entity.LevelLocation = command.LevelLocation;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
