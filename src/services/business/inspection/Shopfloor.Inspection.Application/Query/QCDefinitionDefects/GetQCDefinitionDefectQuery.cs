using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.QCDefinitionDefects
{
    public class GetQCDefinitionDefectQuery : IRequest<Response<QCDefinitionDefect>>
    {
        public int Id { get; set; }
    }
    public class GetQCDefinitionDefectQueryHandler : IRequestHandler<GetQCDefinitionDefectQuery, Response<QCDefinitionDefect>>
    {
        private readonly IQCDefinitionDefectRepository _repository;
        public GetQCDefinitionDefectQueryHandler(IQCDefinitionDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCDefinitionDefect>> Handle(GetQCDefinitionDefectQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new ($"QCDefinitionDefects Not Found (Id:{query.Id}).");
            return new Response<QCDefinitionDefect>(entity);
        }
    }
}
