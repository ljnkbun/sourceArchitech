using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Lights
{
    public class GetLightQuery : IRequest<Response<Light>>
    {
        public int Id { get; set; }
    }
    public class GetLightQueryHandler : IRequestHandler<GetLightQuery, Response<Light>>
    {
        private readonly ILightRepository _repository;
        public GetLightQueryHandler(ILightRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Light>> Handle(GetLightQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Light Not Found (Id:{query.Id}).");
            return new Response<Light>(entity);
        }
    }
}
