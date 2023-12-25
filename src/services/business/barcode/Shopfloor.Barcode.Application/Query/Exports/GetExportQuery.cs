using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Exports
{
    public class GetExportQuery : IRequest<Response<Domain.Entities.Export>>
    {
        public int Id { get; set; }
    }
    public class GetExportEntityQueryHandler : IRequestHandler<GetExportQuery, Response<Domain.Entities.Export>>
    {
        private readonly IExportRepository _repository;
        public GetExportEntityQueryHandler(
            IExportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.Export>> Handle(GetExportQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportByIdAsync(query.Id);
            return entity == null
                ? throw new ApiException($"Recipe Unit Not Found (Id:{query.Id}).")
                : new Response<Domain.Entities.Export>(entity);
        }
    }
}
