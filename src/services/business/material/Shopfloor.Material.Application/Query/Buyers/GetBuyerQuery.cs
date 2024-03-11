using MediatR;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.Buyers
{
    public class GetBuyerQuery : IRequest<Core.Models.Responses.Response<Buyer>>
    {
        public int Id { get; set; }
    }

    public class GetBuyerRequestQueryHandler : IRequestHandler<GetBuyerQuery, Core.Models.Responses.Response<Buyer>>
    {
        private readonly IBuyerRepository _repository;

        public GetBuyerRequestQueryHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Core.Models.Responses.Response<Buyer>> Handle(GetBuyerQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetBuyerByIdAsync(query.Id);
            if (entity == null) return new($"{nameof(Buyer)} Not Found (Id:{query.Id}).");
            return new Core.Models.Responses.Response<Buyer>(entity);
        }
    }
}