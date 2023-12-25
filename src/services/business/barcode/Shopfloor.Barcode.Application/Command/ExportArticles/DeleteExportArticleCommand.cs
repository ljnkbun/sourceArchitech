using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportArticles
{
    public class DeleteExportArticleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteExportArticleEntityCommandHandler : IRequestHandler<DeleteExportArticleCommand, Response<int>>
    {
        private readonly IExportArticleRepository _repository;
        public DeleteExportArticleEntityCommandHandler(IExportArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteExportArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ExportArticleEntity Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
