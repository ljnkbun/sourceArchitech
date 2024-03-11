using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingOperations
{
    public class GetWeavingOperationQuery : IRequest<Response<WeavingOperation>>
    {
        public int Id { get; set; }
    }

    public class GetWeavingOperationQueryHandler : IRequestHandler<GetWeavingOperationQuery, Response<WeavingOperation>>
    {
        private readonly IWeavingOperationRepository _repository;

        public GetWeavingOperationQueryHandler(IWeavingOperationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<WeavingOperation>> Handle(GetWeavingOperationQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWeavingOperationByIdAsync(query.Id);
            if (entity == null) return new($"WeavingOperation Not Found (Id:{query.Id}).");
            return new Response<WeavingOperation>(entity);
        }
    }
}