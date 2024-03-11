using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ColorDefinitions
{
    public class GetColorDefinitionQuery : IRequest<Response<ColorDefinition>>
    {
        public int Id { get; set; }
    }
    public class GetColorDefinitionQueryHandler : IRequestHandler<GetColorDefinitionQuery, Response<ColorDefinition>>
    {
        private readonly IColorDefinitionRepository _repository;
        public GetColorDefinitionQueryHandler(IColorDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ColorDefinition>> Handle(GetColorDefinitionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ColorDefinition Not Found (Id:{query.Id}).");
            return new Response<ColorDefinition>(entity);
        }
    }
}
