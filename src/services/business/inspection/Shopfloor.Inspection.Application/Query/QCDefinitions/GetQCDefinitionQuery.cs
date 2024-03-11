using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefinitions
{
    public class GetQCDefinitionQuery : IRequest<Response<QCDefinition>>
    {
        public int Id { get; set; }
    }
    public class GetQCDefinitionQueryHandler : IRequestHandler<GetQCDefinitionQuery, Response<QCDefinition>>
    {
        private readonly IQCDefinitionRepository _repository;
        public GetQCDefinitionQueryHandler(IQCDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCDefinition>> Handle(GetQCDefinitionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetQCDefinitionWithIncludeById(query.Id);
            if (entity == null) return new ($"QCDefinitions Not Found (Id:{query.Id}).");
            return new Response<QCDefinition>(entity);
        }
    }
}
