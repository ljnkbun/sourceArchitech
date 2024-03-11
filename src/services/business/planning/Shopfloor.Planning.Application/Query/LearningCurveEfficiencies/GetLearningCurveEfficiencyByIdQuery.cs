using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.LearningCurveEfficiencies
{
    public class GetLearningCurveEfficiencyByIdQuery : IRequest<Response<LearningCurveEfficiency>>
    {
        public int Id { get; set; }
    }
    public class GetLearningCurveEfficiencyQueryHandler : IRequestHandler<GetLearningCurveEfficiencyByIdQuery, Response<LearningCurveEfficiency>>
    {
        private readonly ILearningCurveEfficiencyRepository _repository;
        public GetLearningCurveEfficiencyQueryHandler(ILearningCurveEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<LearningCurveEfficiency>> Handle(GetLearningCurveEfficiencyByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"LearningCurveEfficiencies Not Found (Id:{query.Id}).");
            return new Response<LearningCurveEfficiency>(entity);
        }
    }
}
