using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class DeleteExportDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteExportDetailEntityCommandHandler : IRequestHandler<DeleteExportDetailCommand, Response<int>>
    {
        private readonly IExportDetailRepository _repository;
        public DeleteExportDetailEntityCommandHandler(IExportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteExportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ExportDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
