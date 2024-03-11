using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.OrderEfficiencies
{
    public class GetOrderEfficiencyQuery : IRequest<Response<OrderEfficiency>>
    {
        public int Id { get; set; }
    }
    public class GetOrderEfficiencyQueryHandler : IRequestHandler<GetOrderEfficiencyQuery, Response<OrderEfficiency>>
    {
        private readonly IOrderEfficiencyRepository _repository;
        public GetOrderEfficiencyQueryHandler(IOrderEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<OrderEfficiency>> Handle(GetOrderEfficiencyQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"OrderEfficiency Not Found (Id:{query.Id}).");
            return new Response<OrderEfficiency>(entity);
        }
    }
}
