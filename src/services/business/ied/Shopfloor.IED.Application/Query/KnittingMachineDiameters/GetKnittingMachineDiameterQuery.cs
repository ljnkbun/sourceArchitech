using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingMachineDiameters
{
    public class GetKnittingMachineDiameterQuery : IRequest<Response<KnittingMachineDiameter>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingMachineDiameterQueryHandler : IRequestHandler<GetKnittingMachineDiameterQuery, Response<KnittingMachineDiameter>>
    {
        private readonly IKnittingMachineDiameterRepository _repository;
        public GetKnittingMachineDiameterQueryHandler(IKnittingMachineDiameterRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingMachineDiameter>> Handle(GetKnittingMachineDiameterQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingMachineDiameter Not Found (Id:{query.Id}).");
            return new Response<KnittingMachineDiameter>(entity);
        }
    }
}
