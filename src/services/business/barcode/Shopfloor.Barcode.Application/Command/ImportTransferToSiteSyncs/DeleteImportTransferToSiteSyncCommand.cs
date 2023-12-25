using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportTransferToSiteSyns
{
    public class DeleteImportTransferToSiteSyncCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteImportTransferToSiteSyncCommandHandler : IRequestHandler<DeleteImportTransferToSiteSyncCommand, Response<int>>
    {
        private readonly IImportTransferToSiteSyncRepository _repository;
        public DeleteImportTransferToSiteSyncCommandHandler(IImportTransferToSiteSyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteImportTransferToSiteSyncCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ImportTransferToSiteSyn Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
