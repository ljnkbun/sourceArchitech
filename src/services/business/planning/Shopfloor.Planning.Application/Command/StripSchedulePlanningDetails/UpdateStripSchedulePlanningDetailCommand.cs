using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails
{
    public class UpdateStripSchedulePlanningDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal StandardCapacity { get; set; }
        public decimal ActualCapacity { get; set; }
        public decimal ReceivedCapacity { get; set; }
        public string Description { get; set; }
        public int StripScheduleId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateStripSchedulePlanningDetailCommandHandler : IRequestHandler<UpdateStripSchedulePlanningDetailCommand, Response<int>>
    {
        private readonly IStripSchedulePlanningDetailRepository _repository;

        public UpdateStripSchedulePlanningDetailCommandHandler(IStripSchedulePlanningDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateStripSchedulePlanningDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"StripSchedulePlanningDetail Not Found.");

            entity.Date = command.Date;
            entity.StandardCapacity = command.StandardCapacity;
            entity.ActualCapacity = command.ActualCapacity;
            entity.ReceivedCapacity = command.ReceivedCapacity;
            entity.Description = command.Description;
            entity.StripScheduleId = command.StripScheduleId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
