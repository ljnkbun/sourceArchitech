using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.LearningCurveDetailEfficiencies
{
    public class GetLearningCurveDetailEfficiencyByIdQuery : IRequest<Response<LearningCurveDetailEfficiency>>
    {
        public int Id { get; set; }
    }
    public class GetLearningCurveDetailEfficiencyQueryHandler : IRequestHandler<GetLearningCurveDetailEfficiencyByIdQuery, Response<LearningCurveDetailEfficiency>>
    {
        private readonly ILearningCurveDetailEfficiencyRepository _repository;
        public GetLearningCurveDetailEfficiencyQueryHandler(ILearningCurveDetailEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<LearningCurveDetailEfficiency>> Handle(GetLearningCurveDetailEfficiencyByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"LearningCurveDetailEfficiencies Not Found (Id:{query.Id}).");
            return new Response<LearningCurveDetailEfficiency>(entity);
        }
    }
}
