using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingBorderStyles
{
    public class GetWeavingBorderStyleQuery : IRequest<Response<WeavingBorderStyle>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingBorderStyleQueryHandler : IRequestHandler<GetWeavingBorderStyleQuery, Response<WeavingBorderStyle>>
    {
        private readonly IWeavingBorderStyleRepository _repository;
        public GetWeavingBorderStyleQueryHandler(IWeavingBorderStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingBorderStyle>> Handle(GetWeavingBorderStyleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingBorderStyle Not Found (Id:{query.Id}).");
            return new Response<WeavingBorderStyle>(entity);
        }
    }
}
