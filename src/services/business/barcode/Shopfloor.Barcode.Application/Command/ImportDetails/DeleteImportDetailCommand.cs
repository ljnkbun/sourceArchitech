using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class DeleteImportDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteImportDetailCommandHandler : IRequestHandler<DeleteImportDetailCommand, Response<int>>
    {
        private readonly IImportDetailRepository _repository;
        public DeleteImportDetailCommandHandler(IImportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteImportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetImportDetailByIdAsync(command.Id);
            if (entity == null) return new($"ImportDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteImportTransferToSiteDetaiAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
