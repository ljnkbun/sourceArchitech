using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingRates
{
    public class GetSewingRateQuery : IRequest<Response<SewingRate>>
    {
        public int Id { get; set; }
    }
    public class GetSewingRateQueryHandler : IRequestHandler<GetSewingRateQuery, Response<SewingRate>>
    {
        private readonly ISewingRateRepository _repository;
        public GetSewingRateQueryHandler(ISewingRateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingRate>> Handle(GetSewingRateQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingRate Not Found (Id:{query.Id}).");
            return new Response<SewingRate>(entity);
        }
    }
}
