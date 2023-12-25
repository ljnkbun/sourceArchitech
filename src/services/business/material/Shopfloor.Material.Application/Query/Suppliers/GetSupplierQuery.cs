using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.Suppliers
{
    public class GetSupplierQuery : IRequest<Response<Supplier>>
    {
        public int Id { get; set; }
    }

    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, Response<Supplier>>
    {
        private readonly ISupplierRepository _repository;

        public GetSupplierQueryHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Supplier>> Handle(GetSupplierQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Supplier Not Found (Id:{query.Id}).");
            return new Response<Supplier>(entity);
        }
    }
}