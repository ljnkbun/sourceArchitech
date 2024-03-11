using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefinitions
{
    public class GetQCDefinitionByCodeQuery : IRequest<Response<QCDefinition>>
    {
        public string Code { get; set; }
    }
    public class GetQCDefectByQCDefinitionCodeQueryHandler : IRequestHandler<GetQCDefinitionByCodeQuery, Response<QCDefinition>>
    {
        private readonly IQCDefinitionRepository _repository;
        public GetQCDefectByQCDefinitionCodeQueryHandler(IQCDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCDefinition>> Handle(GetQCDefinitionByCodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetQCDefinitionByCode(query.Code);
            if (entity == null) return new ($"QCDefinitions Not Found (Code:{query.Code}).");
            return new Response<QCDefinition>(entity);
        }
    }
}
