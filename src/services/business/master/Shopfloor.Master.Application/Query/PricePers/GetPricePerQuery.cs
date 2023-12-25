using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PricePers
{
    public class GetPricePerQuery : IRequest<Response<PricePer>>
    {
        public int Id { get; set; }
    }
    public class GetPricePerQueryHandler : IRequestHandler<GetPricePerQuery, Response<PricePer>>
    {
        private readonly IPricePerRepository _repository;
        public GetPricePerQueryHandler(IPricePerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<PricePer>> Handle(GetPricePerQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"PricePer Not Found (Id:{query.Id}).");
            return new Response<PricePer>(entity);
        }
    }
}
