using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.StripFactorySchedules;
using Shopfloor.Planning.Application.Command.StripScheduleDetails;
using Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class UpdateStripScheduleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public string Gauge { get; set; }
        public decimal Quantity { get; set; }
        public decimal? ProfileEfficiencyValue { get; set; }
        public decimal? OrderEfficiencyValue { get; set; }
        public decimal? StripEfficiencyValue { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FromWorkingHours { get; set; }
        public int ToWorkingHours { get; set; }
        public string Description { get; set; }
        public bool IsManualPlanning { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateStripFactoryScheduleCommand> StripFactorySchedules { get; set; }
        public ICollection<UpdateStripScheduleDetailCommand> StripScheduleDetails { get; set; }
        public ICollection<UpdateStripSchedulePlanningDetailCommand> StripSchedulePlanningDetails { get; set; }
    }
    public class UpdateStripScheduleCommandHandler : IRequestHandler<UpdateStripScheduleCommand, Response<int>>
    {
        private readonly IStripScheduleRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStripScheduleCommandHandler(IStripScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateStripScheduleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"StripSchedule Not Found.");

            entity.LineId = command.LineId;
            entity.MachineId = command.MachineId;
            entity.ProfileEfficiencyValue = command.ProfileEfficiencyValue;
            entity.OrderEfficiencyValue = command.OrderEfficiencyValue;
            entity.StripEfficiencyValue = command.StripEfficiencyValue;
            entity.LearningCurveEfficiencyId = command.LearningCurveEfficiencyId;
            entity.Gauge = command.Gauge;
            entity.FromDate = command.FromDate;
            entity.ToDate = command.ToDate;
            entity.FromWorkingHours = command.FromWorkingHours;
            entity.ToWorkingHours = command.ToWorkingHours;
            entity.Description = command.Description;
            entity.IsManualPlanning = command.IsManualPlanning;
            entity.IsActive = command.IsActive;
            entity.StripFactorySchedules = _mapper.Map<ICollection<StripFactorySchedule>>(command.StripFactorySchedules);
            entity.StripScheduleDetails = _mapper.Map<ICollection<StripScheduleDetail>>(command.StripScheduleDetails);
            entity.StripSchedulePlanningDetails = _mapper.Map<ICollection<StripSchedulePlanningDetail>>(command.StripSchedulePlanningDetails);

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
