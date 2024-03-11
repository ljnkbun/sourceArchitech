using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ProductGroups
{
    public class GetProductGroupQuery : IRequest<Response<ProductGroup>>
    {
        public int Id { get; set; }
    }
    public class GetProductGroupQueryHandler : IRequestHandler<GetProductGroupQuery, Response<ProductGroup>>
    {
        private readonly IProductGroupRepository _repository;
        public GetProductGroupQueryHandler(IProductGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProductGroup>> Handle(GetProductGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ProductGroup Not Found (Id:{query.Id}).");
            return new Response<ProductGroup>(entity);
        }
    }
}
