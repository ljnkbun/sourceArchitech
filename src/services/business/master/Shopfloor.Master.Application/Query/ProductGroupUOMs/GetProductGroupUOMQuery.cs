using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ProductGroupUOMs
{
    public class GetProductGroupUOMQuery : IRequest<Response<ProductGroupUOM>>
    {
        public int Id { get; set; }
    }

    public class GetProductGroupUOMQueryHandler : IRequestHandler<GetProductGroupUOMQuery, Response<ProductGroupUOM>>
    {
        private readonly IProductGroupUOMRepository _repository;

        public GetProductGroupUOMQueryHandler(IProductGroupUOMRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<ProductGroupUOM>> Handle(GetProductGroupUOMQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ProductGroupUOM Not Found (Id:{query.Id}).");
            return new Response<ProductGroupUOM>(entity);
        }
    }
}