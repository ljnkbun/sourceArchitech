using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationLibResults
{
    public class GetSewingOperationLibResultQuery : IRequest<Response<IReadOnlyList<SewingOperationLibResult>>>
    {
        public int SewingOperationLibId { get; set; }
    }
    public class GetSewingOperationLibResultQueryHandler : IRequestHandler<GetSewingOperationLibResultQuery, Response<IReadOnlyList<SewingOperationLibResult>>>
    {
        private readonly ISewingOperationLibResultRepository _repository;
        public GetSewingOperationLibResultQueryHandler(ISewingOperationLibResultRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<IReadOnlyList<SewingOperationLibResult>>> Handle(GetSewingOperationLibResultQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingOperationLibResultsAsync(query.SewingOperationLibId);
            if (entity == null) return new($"SewingOperationLibResult Not Found.");
            return new Response<IReadOnlyList<SewingOperationLibResult>>(entity);
        }
    }
}
