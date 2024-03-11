using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Buyers
{
    public class GetBuyerQuery : IRequest<Response<Buyer>>
    {
        public int Id { get; set; }
    }
    public class GetBuyerQueryHandler : IRequestHandler<GetBuyerQuery, Response<Buyer>>
    {
        private readonly IBuyerRepository _repository;
        public GetBuyerQueryHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Buyer>> Handle(GetBuyerQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Buyer Not Found (Id:{query.Id}).");
            return new Response<Buyer>(entity);
        }
    }
}
