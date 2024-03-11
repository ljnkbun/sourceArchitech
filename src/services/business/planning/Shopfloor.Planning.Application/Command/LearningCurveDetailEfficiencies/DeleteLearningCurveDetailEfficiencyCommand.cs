using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.LearningCurveDetailEfficiencies
{
    public class DeleteLearningCurveDetailEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLearningCurveDetailEfficiencyCommandHandler : IRequestHandler<DeleteLearningCurveDetailEfficiencyCommand, Response<int>>
    {
        private readonly ILearningCurveDetailEfficiencyRepository _repository;
        public DeleteLearningCurveDetailEfficiencyCommandHandler(ILearningCurveDetailEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLearningCurveDetailEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"LearningCurveDetailEfficiency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
