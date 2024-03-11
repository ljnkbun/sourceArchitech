using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.LearningCurveDetailEfficiencies
{
    public class UpdateLearningCurveDetailEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public int? Days { get; set; }
        public decimal? EfficiencyValue { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateLearningCurveDetailEfficiencyCommandHandler : IRequestHandler<UpdateLearningCurveDetailEfficiencyCommand, Response<int>>
    {
        private readonly ILearningCurveDetailEfficiencyRepository _repository;
        public UpdateLearningCurveDetailEfficiencyCommandHandler(ILearningCurveDetailEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLearningCurveDetailEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"LearningCurveDetailEfficiency Not Found.");

            entity.LearningCurveEfficiencyId = command.LearningCurveEfficiencyId;
            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.EfficiencyValue = command.EfficiencyValue;
            entity.Days = command.Days;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
