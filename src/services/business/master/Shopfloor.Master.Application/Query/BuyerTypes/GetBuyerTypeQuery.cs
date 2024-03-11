using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.BuyerTypes
{
    public class GetBuyerTypeQuery : IRequest<Response<BuyerType>>
    {
        public int Id { get; set; }
    }
    public class GetBuyerTypeQueryHandler : IRequestHandler<GetBuyerTypeQuery, Response<BuyerType>>
    {
        private readonly IBuyerTypeRepository _repository;
        public GetBuyerTypeQueryHandler(IBuyerTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<BuyerType>> Handle(GetBuyerTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"BuyerType Not Found (Id:{query.Id}).");
            return new Response<BuyerType>(entity);
        }
    }
}
