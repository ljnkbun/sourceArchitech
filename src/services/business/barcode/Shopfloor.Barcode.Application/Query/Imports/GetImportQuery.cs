using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Imports
{
    public class GetImportQuery : IRequest<Response<Domain.Entities.Import>>
    {
        public int Id { get; set; }
    }
    public class GetImportQueryHandler : IRequestHandler<GetImportQuery, Response<Domain.Entities.Import>>
    {
        private readonly IImportRepository _repository;
        public GetImportQueryHandler(
            IImportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.Import>> Handle(GetImportQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.ViewImportByIdAsync(query.Id);
            return entity == null
                ? throw new ApiException($"Import Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.Import>(entity);
        }
    }
}
