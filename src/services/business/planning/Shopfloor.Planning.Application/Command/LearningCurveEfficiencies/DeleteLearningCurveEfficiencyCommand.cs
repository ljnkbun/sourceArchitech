using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.LearningCurveEfficiencies
{
    public class DeleteLearningCurveEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLearningCurveEfficiencyCommandHandler : IRequestHandler<DeleteLearningCurveEfficiencyCommand, Response<int>>
    {
        private readonly ILearningCurveEfficiencyRepository _repository;
        public DeleteLearningCurveEfficiencyCommandHandler(ILearningCurveEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLearningCurveEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"LearningCurveEfficiency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
