using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.LearningCurveEfficiencies
{
    public class UpdateLearningCurveEfficiencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateLearningCurveEfficiencyCommandHandler : IRequestHandler<UpdateLearningCurveEfficiencyCommand, Response<int>>
    {
        private readonly ILearningCurveEfficiencyRepository _repository;
        public UpdateLearningCurveEfficiencyCommandHandler(ILearningCurveEfficiencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLearningCurveEfficiencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"LearningCurveEfficiency Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.Description = command.Description;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
