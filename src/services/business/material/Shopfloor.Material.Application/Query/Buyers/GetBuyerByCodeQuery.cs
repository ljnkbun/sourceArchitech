using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.Buyers
{
    public class GetBuyerByCodeQuery : IRequest<Response<Buyer>>
    {
        public string Code { get; set; }
    }

    public class GetBuyerByCodeQueryHandler : IRequestHandler<GetBuyerByCodeQuery, Response<Buyer>>
    {
        private readonly IBuyerRepository _repository;

        public GetBuyerByCodeQueryHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Buyer>> Handle(GetBuyerByCodeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetBuyerByCodeAsync(query.Code);
            if (entity == null) return new($"{nameof(Buyer)} Not Found (Id:{query.Code}).");
            return new Response<Buyer>(entity);
        }
    }
}