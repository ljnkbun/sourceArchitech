using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingShrinkages
{
    public class GetKnittingShrinkageQuery : IRequest<Response<KnittingShrinkage>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingShrinkageQueryHandler : IRequestHandler<GetKnittingShrinkageQuery, Response<KnittingShrinkage>>
    {
        private readonly IKnittingShrinkageRepository _repository;
        public GetKnittingShrinkageQueryHandler(IKnittingShrinkageRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingShrinkage>> Handle(GetKnittingShrinkageQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingShrinkage Not Found (Id:{query.Id}).");
            return new Response<KnittingShrinkage>(entity);
        }
    }
}
