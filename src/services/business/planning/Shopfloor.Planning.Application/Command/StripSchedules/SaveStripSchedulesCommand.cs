using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class SaveStripSchedulesCommand : IRequest<Response<bool>>
    {
        public ICollection<UpdateStripScheduleCommand> StripSchedules { get; set; }
    }
    public class SaveStripSchedulesCommandHandler : IRequestHandler<SaveStripSchedulesCommand, Response<bool>>
    {
        private readonly IStripScheduleRepository _repository;
        private readonly IMapper _mapper;

        public SaveStripSchedulesCommandHandler(IStripScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(SaveStripSchedulesCommand request, CancellationToken cancellationToken)
        {
            if (request.StripSchedules.Count == 0)
                return new($"Data invalid please check again!.");

            var stripScheduleIds = request.StripSchedules.Select(x => x.Id).ToList();

            var dataStripSchedules = await _repository.GetStripScheduleByListId(stripScheduleIds);
            var stripSchedules = new List<StripSchedule>();

            foreach (var item in request.StripSchedules.Where(x => x.Id > 0))
            {
                stripSchedules.Add(UpdateStripStripScheduleAsync(item, dataStripSchedules));
            }

            foreach (var item in request.StripSchedules.Where(x => x.Id == 0))
            {
                var tmp = _mapper.Map<StripSchedule>(item);
                stripSchedules.Add(tmp);
            }

            var result = await _repository.SaveRangeStripSchedule(stripSchedules);
            return new Response<bool>(result);
        }
        private StripSchedule UpdateStripStripScheduleAsync(UpdateStripScheduleCommand item, ICollection<StripSchedule> stripSchedules)
        {
            var entity = stripSchedules.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                entity.IsActive = item.IsActive;
                entity.LineId = item.LineId;
                entity.MachineId = item.MachineId;
                entity.Quantity = item.Quantity;
                entity.ProfileEfficiencyValue = item.ProfileEfficiencyValue;
                entity.OrderEfficiencyValue = item.OrderEfficiencyValue;
                entity.StripEfficiencyValue = item.StripEfficiencyValue;
                entity.LearningCurveEfficiencyId = item.LearningCurveEfficiencyId;
                entity.FromDate = item.FromDate;
                entity.ToDate = item.ToDate;
                entity.FromWorkingHours = item.FromWorkingHours;
                entity.ToWorkingHours = item.ToWorkingHours;
                entity.IsManualPlanning = item.IsManualPlanning;
                entity.Description = item.Description;
                entity.Gauge = item.Gauge;
                entity.StripFactorySchedules = _mapper.Map<ICollection<StripFactorySchedule>>(item.StripFactorySchedules);
                entity.StripScheduleDetails = _mapper.Map<ICollection<StripScheduleDetail>>(item.StripScheduleDetails);
                entity.StripSchedulePlanningDetails = _mapper.Map<ICollection<StripSchedulePlanningDetail>>(item.StripSchedulePlanningDetails);
            }
            return entity;
        }
    }
}