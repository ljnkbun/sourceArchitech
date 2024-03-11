using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Application.Models.StripFactorySchedules;
using Shopfloor.Planning.Application.Models.StripScheduleDetails;
using Shopfloor.Planning.Application.Models.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Models.StripSchedules;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class PullStripScheduleCommand : IRequest<Response<List<CalculateStripScheduleModel>>>
    {
        public int PlanningGroupId { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
    }
    public class PullStripScheduleCommandHandler : IRequestHandler<PullStripScheduleCommand, Response<List<CalculateStripScheduleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IStripScheduleRepository _repository;
        private readonly ILearningCurveEfficiencyRepository _learningCurveEfficiencyRepository;
        private readonly IRequestClientService _requestClientService;
        public PullStripScheduleCommandHandler(IMapper mapper,
            ILearningCurveEfficiencyRepository learningCurveEfficiencyRepository,
        IRequestClientService requestClientService,
            IStripScheduleRepository repository)
        {
            _requestClientService = requestClientService;
            _learningCurveEfficiencyRepository = learningCurveEfficiencyRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<CalculateStripScheduleModel>>> Handle(PullStripScheduleCommand request, CancellationToken cancellationToken)
        {
            var pullStripSchedules = new List<CalculateStripScheduleModel>();

            var dataCalculate = await _requestClientService
               .GetResponseAsync<GetDataCalculateRequest, GetDataCalculateResponse>(new()
               {
                   PlanningGroupId = request.PlanningGroupId,
                   MachineId = request.MachineId,
                   LineId = request.LineId
               }, cancellationToken);

            if (dataCalculate == null || dataCalculate.Message == null)
                return new($"Parameter not true or not exist data with parameter.");

            //get stripschedule by list line/machine
            ICollection<StripSchedule> stripSchedules;
            if (request.MachineId != null && request.MachineId != 0)
            {
                stripSchedules = await _repository.GetStripScheduleByMachineIdAsync((int)request.MachineId);
            }
            else
            {
                stripSchedules = await _repository.GetStripScheduleByLineIdAsync((int)request.LineId);
            }

            // Get List Efficiency 
            var ids = stripSchedules.Where(x => x.LearningCurveEfficiencyId != null && x.LearningCurveEfficiencyId != 0).Select(x => (int)x.LearningCurveEfficiencyId).ToList();

            var learningCurveEfficiencies = await _learningCurveEfficiencyRepository.GetByIdsAsync(ids);

            pullStripSchedules = await PullStripScheduleAsync(stripSchedules.ToList(), learningCurveEfficiencies, dataCalculate.Message.CalendarDetails, dataCalculate.Message.Machine, dataCalculate.Message.Line, cancellationToken);

            return new(pullStripSchedules);
        }


        private async Task<List<CalculateStripScheduleModel>> PullStripScheduleAsync(
            List<StripSchedule> stripSchedules,
            List<LearningCurveEfficiency> learningCurveDetailEfficiencies,
            List<CalendarDetailDto> CalendarDetails, MachineDto machineDto,
            LineDto lineDto, CancellationToken cancellationToken)
        {
            var pullStripSchedules = new List<CalculateStripScheduleModel>();
            // calculate stripschedule
            var fDate = DateTime.Now;

            var fromWH = 0M;
            var toWH = 0M;

            for (int i = 0; i < stripSchedules?.Count(); i++)
            {
                var whs = GetWorkingHours(CalendarDetails, fDate.DayOfWeek);
                var calculateByStripScheduleId = new CalculateStripScheduleModel();

                if (stripSchedules.Count() - 1 == i) // phần tử cuối cùng
                {
                    var firstItem = stripSchedules[i];
                    if (firstItem.FromDate.Date < fDate && firstItem.ToDate.Date > fDate)
                    {
                        return null;
                    }
                    else
                    {
                        if (stripSchedules.Count() > 1)
                        {
                            fromWH = whs - toWH;
                            if (fromWH == 0)
                            {
                                fDate = fDate.AddDays(1);
                            }
                        }
                        else
                        {
                            fromWH = whs;
                        }
                        calculateByStripScheduleId = new CalculateStripScheduleModel()
                        {
                            StripFactoryId = firstItem.StripFactorySchedules.Select(x => x.StripFactoryId).FirstOrDefault(),
                            StripScheduleId = firstItem.Id,
                            LineId = firstItem.LineId,
                            MachineId = firstItem.MachineId,
                            Quantity = firstItem.Quantity,
                            FromDate = fDate,
                            FromWorkingHours = fromWH,
                            ProfileEfficiencyValue = firstItem.ProfileEfficiencyValue ?? 1M,
                            OrderEfficiencyValue = firstItem.OrderEfficiencyValue ?? 1M,
                            StripEfficiencyValue = firstItem.StripEfficiencyValue ?? 1M,
                            LearningCurveEfficiencyId = firstItem.LearningCurveEfficiencyId,
                            StripSchedulePlanningDetails = new List<StripSchedulePlanningDetailModel>(),
                            StripScheduleDetails = _mapper.Map<ICollection<StripScheduleDetailModel>>(firstItem.StripScheduleDetails),
                            StripFactorySchedules = _mapper.Map<ICollection<StripFactoryScheduleModel>>(firstItem.StripFactorySchedules),
                        };

                        var firstStripSchedule = new CalculateStripScheduleModel();
                        if (firstItem.MachineId != 0 && firstItem.MachineId != null)
                        {
                            firstStripSchedule = await CalculatePullStripScheduleForMachineAsync(calculateByStripScheduleId, learningCurveDetailEfficiencies, CalendarDetails, machineDto, cancellationToken);
                        }
                        else
                        {
                            firstStripSchedule = await CalculatePullStripScheduleForLineAsync(calculateByStripScheduleId, learningCurveDetailEfficiencies, CalendarDetails, lineDto, cancellationToken);
                        }
                        pullStripSchedules.Add(firstStripSchedule);
                        return pullStripSchedules;
                    }
                }
                else
                {
                    var item = stripSchedules.ElementAt(i);
                    if (item.FromDate.Date < fDate && item.ToDate.Date > fDate)// phần tử đầu tiên
                    {
                        fDate = item.ToDate.Date;
                        toWH = item.ToWorkingHours;
                        fromWH = whs - item.FromWorkingHours;

                        var firstStripSchedule = new CalculateStripScheduleModel()
                        {
                            StripFactoryId = item.StripFactorySchedules.Select(x => x.StripFactoryId).FirstOrDefault(),
                            StripScheduleId = item.Id,
                            LineId = item.LineId,
                            MachineId = item.MachineId,
                            Quantity = item.Quantity,
                            FromDate = item.FromDate,
                            ToDate = item.ToDate,
                            FromWorkingHours = item.FromWorkingHours,
                            ToWorkingHours = item.ToWorkingHours,
                            ProfileEfficiencyValue = item.ProfileEfficiencyValue ?? 1M,
                            OrderEfficiencyValue = item.OrderEfficiencyValue ?? 1M,
                            StripEfficiencyValue = item.StripEfficiencyValue ?? 1M,
                            LearningCurveEfficiencyId = item.LearningCurveEfficiencyId,
                            Description = item.Description,
                            StripSchedulePlanningDetails = _mapper.Map<ICollection<StripSchedulePlanningDetailModel>>(item.StripSchedulePlanningDetails),
                            StripScheduleDetails = _mapper.Map<ICollection<StripScheduleDetailModel>>(item.StripScheduleDetails),
                            StripFactorySchedules = _mapper.Map<ICollection<StripFactoryScheduleModel>>(item.StripFactorySchedules),
                        };

                        pullStripSchedules.Add(firstStripSchedule);
                        continue;
                    }
                    else
                    {
                        fromWH = whs - toWH;
                        if (fromWH == 0)
                        {
                            fDate = fDate.AddDays(1);
                        }
                    }
                    calculateByStripScheduleId = new CalculateStripScheduleModel()
                    {
                        StripFactoryId = item.StripFactorySchedules.Select(x => x.StripFactoryId).FirstOrDefault(),
                        StripScheduleId = item.Id,
                        LineId = item.LineId,
                        MachineId = item.MachineId,
                        Quantity = item.Quantity,
                        FromDate = fDate,
                        FromWorkingHours = fromWH,
                        ProfileEfficiencyValue = item.ProfileEfficiencyValue ?? 1M,
                        OrderEfficiencyValue = item.OrderEfficiencyValue ?? 1M,
                        StripEfficiencyValue = item.StripEfficiencyValue ?? 1M,
                        LearningCurveEfficiencyId = item.LearningCurveEfficiencyId,
                        StripSchedulePlanningDetails = new List<StripSchedulePlanningDetailModel>(),
                        StripScheduleDetails = _mapper.Map<ICollection<StripScheduleDetailModel>>(item.StripScheduleDetails),
                        StripFactorySchedules = _mapper.Map<ICollection<StripFactoryScheduleModel>>(item.StripFactorySchedules),
                    };
                    var tmpStripSchedule = new CalculateStripScheduleModel();
                    if (item.MachineId != 0 && item.MachineId != null)
                    {
                        tmpStripSchedule = await CalculatePullStripScheduleForMachineAsync(calculateByStripScheduleId, learningCurveDetailEfficiencies, CalendarDetails, machineDto, cancellationToken);
                    }
                    else
                    {
                        tmpStripSchedule = await CalculatePullStripScheduleForLineAsync(calculateByStripScheduleId, learningCurveDetailEfficiencies, CalendarDetails, lineDto, cancellationToken);
                    }

                    fDate = calculateByStripScheduleId.ToDate;
                    toWH = calculateByStripScheduleId.ToWorkingHours;

                    pullStripSchedules.Add(tmpStripSchedule);

                }
            }
            return pullStripSchedules;
        }

        private async Task<CalculateStripScheduleModel> CalculatePullStripScheduleForMachineAsync(
            CalculateStripScheduleModel stripSchedule,
            List<LearningCurveEfficiency> learningCurveEfficiencies,
            List<CalendarDetailDto> calendarDetails, MachineDto machineDto,
            CancellationToken cancellationToken)
        {
            var learningCurveEfficiency = learningCurveEfficiencies.Find(x => x.Id == stripSchedule.LearningCurveEfficiencyId);

            var tempQuantity = stripSchedule.Quantity;
            var date = stripSchedule.FromDate;
            var hours = stripSchedule.FromWorkingHours;
            if (stripSchedule.FromWorkingHours == 0)
            {
                date = date.AddDays(1);
                hours = GetWorkingHours(calendarDetails, date.DayOfWeek);
            }
            var tmp = 0;
            while (tempQuantity > 0)
            {
                var learningCurve = 1M;

                if (tmp < learningCurveEfficiency?.LearningCurveDetailEfficiencies.Count())
                {
                    learningCurve = (learningCurveEfficiency?.LearningCurveDetailEfficiencies.Select(x => x.EfficiencyValue).Skip(tmp).First()) ?? 1M;
                }
                var sspd = new StripSchedulePlanningDetailModel();

                var standardCapacity = (GetWorkingHours(calendarDetails, date.DayOfWeek) * machineDto.Capacity) ?? 0M;
                var actualCapacity = (((machineDto.Capacity * hours) * stripSchedule.ProfileEfficiencyValue) * stripSchedule.OrderEfficiencyValue) * learningCurve ?? 0M;

                sspd.Date = date;
                sspd.WorkingHours = hours;
                sspd.StandardCapacity = standardCapacity;
                sspd.ActualCapacity = (tempQuantity <= actualCapacity ? tempQuantity : actualCapacity);
                sspd.ReceivedCapacity = 0M;
                sspd.IsActive = true;

                stripSchedule.StripSchedulePlanningDetails.Add(sspd);
                if (tempQuantity <= actualCapacity)
                {
                    stripSchedule.ToDate = date;
                    stripSchedule.ToWorkingHours = standardCapacity != 0 ? Math.Round((tempQuantity * hours) / standardCapacity) : 0;
                    sspd.WorkingHours = standardCapacity != 0 ? Math.Round((tempQuantity * hours) / standardCapacity) : 0;
                    return stripSchedule;
                }
                if (standardCapacity != 0)
                {
                    tempQuantity -= actualCapacity;
                    if (tempQuantity < 0)
                        return stripSchedule;
                }
                tmp++;
                date = date.AddDays(1);
                hours = GetWorkingHours(calendarDetails, date.DayOfWeek);
            }
            return stripSchedule;
        }
        private async Task<CalculateStripScheduleModel> CalculatePullStripScheduleForLineAsync(
            CalculateStripScheduleModel stripSchedule,
            List<LearningCurveEfficiency> learningCurveEfficiencies,
            List<CalendarDetailDto> calendarDetails, LineDto lineDto,
            CancellationToken cancellationToken)
        {

            var learningCurveEfficiency = learningCurveEfficiencies.Find(x => x.Id == stripSchedule.LearningCurveEfficiencyId);

            var tempQuantity = stripSchedule.Quantity;
            var date = stripSchedule.FromDate;
            var hours = stripSchedule.FromWorkingHours;
            if (stripSchedule.FromWorkingHours == 0)
            {
                date = date.AddDays(1);
                hours = GetWorkingHours(calendarDetails, date.DayOfWeek);
            }
            var tmp = 0;
            while (tempQuantity > 0)
            {
                var learningCurve = 1M;
                if (tmp < learningCurveEfficiency?.LearningCurveDetailEfficiencies.Count())
                {
                    learningCurve = (learningCurveEfficiency?.LearningCurveDetailEfficiencies.Select(x => x.EfficiencyValue).Skip(tmp).First()) ?? 1M;
                }

                var sspd = new StripSchedulePlanningDetailModel();

                var standardCapacity = (GetWorkingHours(calendarDetails, date.DayOfWeek) * lineDto.Worker) ?? 0M;
                var actualCapacity = (((lineDto.Worker * hours) * (stripSchedule.ProfileEfficiencyValue ?? 1M)) * (stripSchedule.ProfileEfficiencyValue ?? 1M)) * learningCurve ?? 0M;

                sspd.Date = date;
                sspd.WorkingHours = hours;
                sspd.StandardCapacity = standardCapacity;
                sspd.ActualCapacity = (tempQuantity <= actualCapacity ? tempQuantity : actualCapacity);
                sspd.ReceivedCapacity = 0M;
                sspd.IsActive = true;

                stripSchedule.StripSchedulePlanningDetails.Add(sspd);
                if (tempQuantity <= actualCapacity)
                {
                    stripSchedule.ToDate = date;
                    stripSchedule.ToWorkingHours = standardCapacity != 0 ? Math.Round((tempQuantity * hours) / standardCapacity) : 0;
                    sspd.WorkingHours = standardCapacity != 0 ? Math.Round((tempQuantity * hours) / standardCapacity) : 0;
                    return stripSchedule;
                }
                if (standardCapacity != 0)
                {
                    tempQuantity -= actualCapacity;
                    if (tempQuantity < 0)
                        return stripSchedule;
                }
                tmp++;
                date = date.AddDays(1);
                hours = GetWorkingHours(calendarDetails, date.DayOfWeek);
            }
            return stripSchedule;
        }

        private static decimal GetWorkingHours(List<CalendarDetailDto> calendarDetails, DayOfWeek dayOfWeek)
        {
            var dayDetail = calendarDetails.Find(x => x.DayOfWeek == dayOfWeek);
            return dayDetail?.WorkingHours ?? 0;
        }
    }
}

