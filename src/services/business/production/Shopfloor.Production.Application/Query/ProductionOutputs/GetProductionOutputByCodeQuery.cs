using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.ProductionOutputs
{
    public class GetProductionOutputByCodeQuery : IRequest<Response<ProductionOutput>>
    {
        public string Code { get; set; }
    }
    public class GetProductionOutputByCodeQueryHandler : IRequestHandler<GetProductionOutputByCodeQuery, Response<ProductionOutput>>
    {
        private readonly IProductionOutputRepository _repository;
        public GetProductionOutputByCodeQueryHandler(IProductionOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProductionOutput>> Handle(GetProductionOutputByCodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetDeepByCodeAsync(query.Code);
            if (entity == null) return new($"ProductionOutput Not Found (Code:{query.Code}).");
            return new Response<ProductionOutput>(entity);
        }
    }
}
