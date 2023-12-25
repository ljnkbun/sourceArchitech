using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Concentrates
{
    public class GetConcentrateQuery : IRequest<Response<Concentrate>>
    {
        public int Id { get; set; }
    }
    public class GetConcentrateQueryHandler : IRequestHandler<GetConcentrateQuery, Response<Concentrate>>
    {
        private readonly IConcentrateRepository _repository;
        public GetConcentrateQueryHandler(IConcentrateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Concentrate>> Handle(GetConcentrateQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Concentrate Not Found (Id:{query.Id}).");
            return new Response<Concentrate>(entity);
        }
    }
}
