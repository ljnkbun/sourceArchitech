using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperations
{
    public class GetSewingOperationQuery : IRequest<Response<SewingOperation>>
    {
        public int Id { get; set; }
    }
    public class GetSewingOperationQueryHandler : IRequestHandler<GetSewingOperationQuery, Response<SewingOperation>>
    {
        private readonly ISewingOperationRepository _repository;
        public GetSewingOperationQueryHandler(ISewingOperationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingOperation>> Handle(GetSewingOperationQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingOperationByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingOperation Not Found (Id:{query.Id}).");
            return new Response<SewingOperation>(entity);
        }
    }
}
