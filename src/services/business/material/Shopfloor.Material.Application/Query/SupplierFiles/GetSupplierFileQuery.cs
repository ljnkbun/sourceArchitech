using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.SupplierFiles
{
    public class GetSupplierFileQuery : IRequest<Response<Domain.Entities.SupplierFile>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierFileQueryHandler : IRequestHandler<GetSupplierFileQuery, Response<Domain.Entities.SupplierFile>>
    {
        private readonly ISupplierFileRepository _repository;

        public GetSupplierFileQueryHandler(ISupplierFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.SupplierFile>> Handle(GetSupplierFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SupplierFile Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.SupplierFile>(entity);
        }
    }
}