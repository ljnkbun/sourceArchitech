using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SupplierTypes
{
    public class GetSupplierTypeQuery : IRequest<Response<SupplierType>>
    {
        public int Id { get; set; }
    }
    public class GetSupplierTypeQueryHandler : IRequestHandler<GetSupplierTypeQuery, Response<SupplierType>>
    {
        private readonly ISupplierTypeRepository _repository;
        public GetSupplierTypeQueryHandler(ISupplierTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SupplierType>> Handle(GetSupplierTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SupplierType Not Found (Id:{query.Id}).");
            return new Response<SupplierType>(entity);
        }
    }
}
