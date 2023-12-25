using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationWFXs
{
    public class GetSewingOperationWFXQuery : IRequest<Response<SewingOperationWFX>>
    {
        public int Id { get; set; }
        public int Version { get; set; }
    }
    public class GetSewingOperationWFXQueryHandler : IRequestHandler<GetSewingOperationWFXQuery, Response<SewingOperationWFX>>
    {
        private readonly ISewingOperationWFXRepository _repository;

        public GetSewingOperationWFXQueryHandler(ISewingOperationWFXRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingOperationWFX>> Handle(GetSewingOperationWFXQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingOperationWFXAsync(query.Id, query.Version);
            if (entity == null) throw new ApiException($"SewingOperationWFX Not Found (Id:{query.Id}).");

            return new Response<SewingOperationWFX>(entity);
        }
    }
}
