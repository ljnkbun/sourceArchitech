using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingSubOperationWFXResults
{
    public class GetSewingSubOperationWFXResultQuery : IRequest<Response<IReadOnlyList<SewingSubOperationWFXResult>>>
    {
        public int SewingSubOperationWFXId { get; set; }
    }
    public class GetSewingSubOperationWFXResultQueryHandler : IRequestHandler<GetSewingSubOperationWFXResultQuery, Response<IReadOnlyList<SewingSubOperationWFXResult>>>
    {
        private readonly ISewingSubOperationWFXResultRepository _repository;
        public GetSewingSubOperationWFXResultQueryHandler(ISewingSubOperationWFXResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<IReadOnlyList<SewingSubOperationWFXResult>>> Handle(GetSewingSubOperationWFXResultQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingSubOperationWFXResultsAsync(query.SewingSubOperationWFXId);
            if (entity == null) throw new ApiException($"SewingSubOperationWFXResult Not Found.");
            return new Response<IReadOnlyList<SewingSubOperationWFXResult>>(entity);
        }
    }
}
