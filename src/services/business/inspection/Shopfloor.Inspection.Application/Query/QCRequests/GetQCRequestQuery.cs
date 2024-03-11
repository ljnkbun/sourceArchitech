using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCRequests
{
    public class GetQCRequestQuery : IRequest<Response<QCRequest>>
    {
        public int Id { get; set; }
    }
    public class GetQCRequestQueryHandler : IRequestHandler<GetQCRequestQuery, Response<QCRequest>>
    {
        private readonly IQCRequestRepository _repository;
         private readonly IQCDefinitionRepository _repositoryQCDefinition;
        public GetQCRequestQueryHandler(IQCRequestRepository repository, IQCDefinitionRepository repositoryQCDefinition)
        {
            _repository = repository;
            _repositoryQCDefinition = repositoryQCDefinition;
        }
        public async Task<Response<QCRequest>> Handle(GetQCRequestQuery query, CancellationToken cancellationToken)
        {
            var qcRequest =  await _repository.GetByIdAsync(query.Id);
            var qcType = await _repositoryQCDefinition.GetQCTypeByQCDefinitionCode(qcRequest.QCDefinitionCode);
            var entity = await _repository.GetQCRequesWithDetailByIdAsync(query.Id, qcType.QCScreenType);
            if (entity == null) return new($"QCRequests Not Found (Id:{query.Id}).");
            return new Response<QCRequest>(entity);
        }
    }
}
