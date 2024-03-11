using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationLibs
{
    public class GetSewingOperationLibQuery : IRequest<Response<SewingOperationLib>>
    {
        public int Id { get; set; }
    }
    public class GetSewingOperationLibQueryHandler : IRequestHandler<GetSewingOperationLibQuery, Response<SewingOperationLib>>
    {
        private readonly ISewingOperationLibRepository _repository;
        public GetSewingOperationLibQueryHandler(ISewingOperationLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingOperationLib>> Handle(GetSewingOperationLibQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingOperationLibByIdAsync(query.Id);
            if (entity == null) return new($"SewingOperationLib Not Found (Id:{query.Id}).");
            return new Response<SewingOperationLib>(entity);
        }
    }
}
