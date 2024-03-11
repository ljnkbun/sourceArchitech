using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.ProductionOutputs
{
    public class GetProductionOutputQuery : IRequest<Response<ProductionOutput>>
    {
        public int Id { get; set; }
    }
    public class GetProductionOutputQueryHandler : IRequestHandler<GetProductionOutputQuery, Response<ProductionOutput>>
    {
        private readonly IProductionOutputRepository _repository;
        public GetProductionOutputQueryHandler(IProductionOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProductionOutput>> Handle(GetProductionOutputQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetDeepByIdAsync(query.Id);
            if (entity == null) return new($"ProductionOutput Not Found (Id:{query.Id}).");
            return new Response<ProductionOutput>(entity);
        }
    }
}
