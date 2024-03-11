using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCTypes
{
    public class GetQCTypeByQCDefineCodeQuery : IRequest<Response<QCType>>
    {
        public string QcDefineCode { get; set; }
    }
    public class GetQCTypeByQCDefineCodeQueryHandler : IRequestHandler<GetQCTypeByQCDefineCodeQuery, Response<QCType>>
    {
        private readonly IQCDefinitionRepository _repository;
        public GetQCTypeByQCDefineCodeQueryHandler(IQCDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<QCType>> Handle(GetQCTypeByQCDefineCodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetQCTypeByQCDefinitionCode(query.QcDefineCode);
            if (entity == null) return new($"QCTypes Not Found (QcDefineCode:{query.QcDefineCode}).");
            return new Response<QCType>(entity);
        }
    }
}
