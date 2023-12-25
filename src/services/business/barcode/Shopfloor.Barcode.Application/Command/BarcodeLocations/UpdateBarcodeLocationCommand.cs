using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.BarcodeLocations
{
    public class UpdateBarcodeLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ArticleBarcodeId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateBarcodeLocationCommandHandler : IRequestHandler<UpdateBarcodeLocationCommand, Response<int>>
    {
        private readonly IBarcodeLocationRepository _repository;
        public UpdateBarcodeLocationCommandHandler(IBarcodeLocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateBarcodeLocationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"BarcodeLocation Not Found.");


            entity.LocationId = command.LocationId;
            entity.ArticleBarcodeId = command.ArticleBarcodeId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
