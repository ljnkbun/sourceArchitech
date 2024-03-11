using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Exports
{
    public class DeleteExportCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteExportEntityCommandHandler : IRequestHandler<DeleteExportCommand, Response<int>>
    {
        private readonly IExportRepository _repository;
        public DeleteExportEntityCommandHandler(IExportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteExportCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ExportEntity Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
