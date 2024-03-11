using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.YarnCompositions
{
    public class GetYarnCompositionQuery : IRequest<Response<YarnComposition>>
    {
        public int Id { get; set; }
    }
    public class GetYarnCompositionQueryHandler : IRequestHandler<GetYarnCompositionQuery, Response<YarnComposition>>
    {
        private readonly IYarnCompositionRepository _repository;
        public GetYarnCompositionQueryHandler(IYarnCompositionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<YarnComposition>> Handle(GetYarnCompositionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"YarnComposition Not Found (Id:{query.Id}).");
            return new Response<YarnComposition>(entity);
        }
    }
}
