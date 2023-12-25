using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.ImportTransferToSiteSyncs
{
    public class GetImportTransferToSiteSynQuery : IRequest<Response<Domain.Entities.ImportTransferToSiteSync>>
    {
        public int Id { get; set; }
    }
    public class ImportTransferToSiteSyncQueryHandler : IRequestHandler<GetImportTransferToSiteSynQuery, Response<Domain.Entities.ImportTransferToSiteSync>>
    {
        private readonly IImportTransferToSiteSyncRepository _repository;
        public ImportTransferToSiteSyncQueryHandler(
            IImportTransferToSiteSyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.ImportTransferToSiteSync>> Handle(GetImportTransferToSiteSynQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            return entity == null
                ? throw new ApiException($"ImportTransferToSiteSync Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.ImportTransferToSiteSync>(entity);
        }
    }
}
