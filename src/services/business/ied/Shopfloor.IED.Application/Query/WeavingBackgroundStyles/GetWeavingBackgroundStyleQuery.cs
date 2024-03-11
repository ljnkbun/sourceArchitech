using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingBackgroundStyles
{
    public class GetWeavingBackgroundStyleQuery : IRequest<Response<WeavingBackgroundStyle>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingBackgroundStyleQueryHandler : IRequestHandler<GetWeavingBackgroundStyleQuery, Response<WeavingBackgroundStyle>>
    {
        private readonly IWeavingBackgroundStyleRepository _repository;
        public GetWeavingBackgroundStyleQueryHandler(IWeavingBackgroundStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingBackgroundStyle>> Handle(GetWeavingBackgroundStyleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingBackgroundStyle Not Found (Id:{query.Id}).");
            return new Response<WeavingBackgroundStyle>(entity);
        }
    }
}
