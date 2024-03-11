using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Suppliers
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
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Supplier Not Found (Id:{query.Id}).");
            return new Response<Supplier>(entity);
        }
    }
}
