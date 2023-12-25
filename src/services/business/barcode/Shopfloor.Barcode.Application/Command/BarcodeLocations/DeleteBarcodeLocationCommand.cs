using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Command.BarcodeLocations
{
    public class DeleteBarcodeLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteBarcodeLocationCommandHandler : IRequestHandler<DeleteBarcodeLocationCommand, Response<int>>
    {
        private readonly IBarcodeLocationRepository _repository;
        public DeleteBarcodeLocationCommandHandler(IBarcodeLocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteBarcodeLocationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"BarcodeLocation Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
