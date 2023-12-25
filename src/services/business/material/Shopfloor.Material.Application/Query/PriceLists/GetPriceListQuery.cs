using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.PriceLists
{
    public class GetPriceListQuery : IRequest<Response<Domain.Entities.PriceList>>
    {
        public int Id { get; set; }
    }

    public class GetPriceListQueryHandler : IRequestHandler<GetPriceListQuery, Response<Domain.Entities.PriceList>>
    {
        private readonly IPriceListRepository _repository;

        public GetPriceListQueryHandler(IPriceListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.PriceList>> Handle(GetPriceListQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"PriceList Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.PriceList>(entity);
        }
    }
}