using AutoMapper;
using MassTransit.Initializers;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.Masters.Calendars;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Application.Models.StripFactoryDetails;
using Shopfloor.Planning.Application.Models.StripFactorySchedules;
using Shopfloor.Planning.Application.Models.StripScheduleDetails;
using Shopfloor.Planning.Application.Models.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Models.StripSchedules;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class CalculateStripScheduleCommand : IRequest<Response<CalculateStripScheduleModel>>
    {
        public int? StripFactoryScheduleId { get; set; } // splitbatch
        public int? StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public int? MachineId { get; set; }
        public int? LineId { get; set; }
        public DateTime FromDate { get; set; }
        public int FromWorkingHours { get; set; }
        public int CalendarId { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public CalculateStripFactoryScheduleModel StripFactorySchedules { get; set; }
        public List<CalculateStripScheduleDetailModel> StripScheduleDetails { get; set; }
        public List<CalculateStripFactoryDetailModel> StripFactoryDetails { get; set; }
    }
    public class CalculateStripScheduleCommandHandler : IRequestHandler<CalculateStripScheduleCommand, Response<CalculateStripScheduleModel>>
    {
        private readonly IRequestClientService _requestClientService;
        private readonly IStripFactoryRepository _stripFactoryRepository;
        private readonly IPORRepository _pORRepository;
        private readonly IProfileEfficiencyRepository _profileEfficiencyRepository;
        private readonly IOrderEfficiencyRepository _orderEfficiencyRepository;
        private readonly IStripFactoryScheduleRepository _stripFactoryScheduleRepository;
        private readonly ILearningCurveEfficiencyRepository _learningCurveEfficiencyRepository;
        private readonly IStripScheduleRepository _stripScheduleRepository;
        private readonly IMapper _mapper;
        public CalculateStripScheduleCommandHandler(IMapper mapper,
            IRequestClientService requestClientService,
            IStripFactoryRepository stripFactoryRepository,
            IProfileEfficiencyRepository profileEfficiencyRepository,
            IOrderEfficiencyRepository orderEfficiencyRepository,
            IStripFactoryScheduleRepository stripFactoryScheduleRepository,
            ILearningCurveEfficiencyRepository learningCurveEfficiencyRepository,
            IStripScheduleRepository stripScheduleRepository,
            IPORRepository pORRepository)
        {
            _requestClientService = requestClientService;
            _stripFactoryRepository = stripFactoryRepository;
            _profileEfficiencyRepository = profileEfficiencyRepository;
            _orderEfficiencyRepository = orderEfficiencyRepository;
            _stripFactoryScheduleRepository = stripFactoryScheduleRepository;
            _learningCurveEfficiencyRepository = learningCurveEfficiencyRepository;
            _pORRepository = pORRepository;
            _stripScheduleRepository = stripScheduleRepository;
            _mapper = mapper;
        }

        public async Task<Response<CalculateStripScheduleModel>> Handle(CalculateStripScheduleCommand request, CancellationToken cancellationToken)
        {

            var calendarRes = await _requestClientService
                .GetResponseAsync<GetCalendarByIdRequest, GetCalendarByIdResponse>(new() { Id = request.CalendarId }, cancellationToken);
            if (calendarRes == null || calendarRes.Message == null)
                return new($"Calendar Not Found. Id={request.CalendarId}");



            StripFactorySchedule sfs = new StripFactorySchedule();

            // Get learningcurve efficiency
            LearningCurveEfficiency learningCurve = new LearningCurveEfficiency();
            var profileEfficiencyValue = 1M;
            var orderEfficiencyValue = 1M;
            if (request.LearningCurveEfficiencyId != null)
            {
                learningCurve = await _learningCurveEfficiencyRepository.GetByIdAsync((int)request.LearningCurveEfficiencyId);
            }



            StripFactory stripFactory = new StripFactory();
            var por = new POR();
            var stripSchedule = new StripSchedule();

            var quantitySumSSD = 0M;

            #region Calculate By StripSchedule Id
            if (request.StripScheduleId != null)
            {
                stripSchedule = await _stripScheduleRepository.GetByIdAsync((int)request.StripScheduleId);

                if (stripSchedule != null)
                {

                    ICollection<StripScheduleDetailModel> stripScheduleDetail;
                    if (request.StripScheduleDetails != null && request.StripScheduleDetails?.Count != 0)
                    {
                        stripScheduleDetail = _mapper.Map<ICollection<StripScheduleDetailModel>>(request.StripScheduleDetails);
                        quantitySumSSD = stripScheduleDetail.Sum(x => x.Quantity);
                    }
                    else
                    {
                        stripScheduleDetail = _mapper.Map<ICollection<StripScheduleDetailModel>>(stripSchedule.StripScheduleDetails);
                        quantitySumSSD = stripScheduleDetail.Sum(x => x.Quantity);
                    }

                    var sfId = stripSchedule.StripFactorySchedules.Select(x => x.StripFactoryId).FirstOrDefault();

                    var sf = await _stripFactoryRepository.GetByIdAsync(sfId);

                    var sfsBystripSchedule = stripSchedule.StripFactorySchedules;

                    var calculateByStripScheduleId = new CalculateStripScheduleModel()
                    {
                        StripFactoryId = stripSchedule.StripFactorySchedules.Select(x => x.StripFactoryId).FirstOrDefault(),
                        StripScheduleId = stripSchedule.Id,
                        LineId = stripSchedule.LineId,
                        MachineId = stripSchedule.MachineId,
                        Quantity = quantitySumSSD,
                        FromDate = request.FromDate,
                        FromWorkingHours = request.FromWorkingHours,
                        ProfileEfficiencyValue = stripSchedule.ProfileEfficiencyValue ?? 1M,
                        OrderEfficiencyValue = stripSchedule.OrderEfficiencyValue ?? 1M,
                        LearningCurveEfficiencyId = stripSchedule.LearningCurveEfficiencyId,
                        StripSchedulePlanningDetails = new List<StripSchedulePlanningDetailModel>(),
                        StripScheduleDetails = stripScheduleDetail,
                        StripFactoryDetails = _mapper.Map<ICollection<StripFactoryDetailModel>>(sf.StripFactoryDetails),
                        StripFactorySchedules = _mapper.Map<ICollection<StripFactoryScheduleModel>>(sfsBystripSchedule),
                    };

                    if (request.LineId > 0)
                        return new(await CalculateForLineAsync(calculateByStripScheduleId, stripFactory, calendarRes.Message, learningCurve, cancellationToken));

                    return new(await CalculateForMachineAsync(calculateByStripScheduleId, stripFactory, calendarRes.Message, learningCurve, cancellationToken));
                }

            }
            #endregion

            #region Split Batch

            // Split Batch
            // nếu StripFactoryScheduleId != null => lấy quantity của StripFactoryScheduleId để calculate 

            if (request.StripFactoryScheduleId != null)
            {
                sfs = await _stripFactoryScheduleRepository.GetByIdAsync((int)request.StripFactoryScheduleId);
                if (sfs != null)
                {
                    var sf = await _stripFactoryRepository.GetByIdAsync(sfs.StripFactoryId);

                    //Get POR
                    var porbySF = await _pORRepository.GetByIdAsync(sf.PORId);

                    // Get efficiency

                    // ProfileEfficiencyValue 
                    profileEfficiencyValue = await _profileEfficiencyRepository.GetProfileEfficiencyValueAsync(porbySF.Category, porbySF.ProductGroup, porbySF.SubCategory);

                    // OrderEfficiencyValue
                    orderEfficiencyValue = await _orderEfficiencyRepository.GetOrderEfficiencyValueAsync(porbySF.OCNo);

                    var calculateByStripScheduleId = new CalculateStripScheduleModel()
                    {
                        StripFactoryId = sf.Id,
                        LineId = request.LineId,
                        MachineId = request.MachineId,
                        Quantity = sfs.Quantity,
                        FromDate = request.FromDate,
                        FromWorkingHours = request.FromWorkingHours,
                        ProfileEfficiencyValue = profileEfficiencyValue,
                        OrderEfficiencyValue = orderEfficiencyValue,
                        LearningCurveEfficiencyId = request.LearningCurveEfficiencyId,
                        StripSchedulePlanningDetails = new List<StripSchedulePlanningDetailModel>(),
                        StripFactoryDetails = _mapper.Map<ICollection<StripFactoryDetailModel>>(sf.StripFactoryDetails),
                        StripFactorySchedules = _mapper.Map<ICollection<StripFactoryScheduleModel>>(sfs),
                    };

                    if (request.LineId > 0)
                        return new(await CalculateForLineAsync(calculateByStripScheduleId, stripFactory, calendarRes.Message, learningCurve, cancellationToken));

                    return new(await CalculateForMachineAsync(calculateByStripScheduleId, stripFactory, calendarRes.Message, learningCurve, cancellationToken));
                }
            }
            #endregion

            #region Calculate Strip Factory

            if (request.StripFactoryId != null)
            {
                stripFactory = await _stripFactoryRepository.GetByIdAsync((int)request.StripFactoryId);
                if (stripFactory == null)
                    return new($"StripFactory Not Found. Id={request.StripFactoryId}");

                por = await _pORRepository.GetByIdAsync(stripFactory.PORId);

                if (por == null)
                    return new($"POR Not Found. Id={stripFactory.PORId}");

                ICollection<StripFactoryDetailModel> stripFactoryDetail;
                var quantitySumSFD = 0M;
                if (request.StripFactoryDetails != null && request.StripFactoryDetails?.Count != 0)
                {
                    stripFactoryDetail = _mapper.Map<ICollection<StripFactoryDetailModel>>(request.StripFactoryDetails);
                    quantitySumSFD = stripFactoryDetail.Sum(x => x.Quantity);
                }
                else
                {
                    stripFactoryDetail = _mapper.Map<ICollection<StripFactoryDetailModel>>(stripFactory.StripFactoryDetails);
                    quantitySumSFD = stripFactoryDetail.Sum(x => x.RemainingQuantity);
                }

                List<StripScheduleDetailModel> listSSD = new List<StripScheduleDetailModel>();

                foreach (var item in stripFactory.StripFactoryDetails)
                {
                    var ssd = new StripScheduleDetailModel();

                    ssd.Color = item.Color;
                    ssd.Size = item.Size;
                    ssd.UOM = item.UOM;
                    ssd.Quantity = item.Quantity;

                    listSSD.Add(ssd);
                }

                var CalculateSFS = new List<CalculateStripFactoryScheduleModel>()
                {
                    new CalculateStripFactoryScheduleModel()
                    {
                    StripFactoryId = stripFactory.Id,
                    Quantity = stripFactory.RemainningQuantity
                    }
                };

                var stripScheduleCalculate = new CalculateStripScheduleModel()
                {
                    StripFactoryId = request.StripFactoryId,
                    StripScheduleId = request.StripScheduleId,
                    LineId = request.LineId,
                    MachineId = request.MachineId,
                    Quantity = quantitySumSFD,
                    FromDate = request.FromDate,
                    FromWorkingHours = request.FromWorkingHours,
                    ProfileEfficiencyValue = profileEfficiencyValue,
                    OrderEfficiencyValue = orderEfficiencyValue,
                    LearningCurveEfficiencyId = request.LearningCurveEfficiencyId,
                    StripSchedulePlanningDetails = new List<StripSchedulePlanningDetailModel>(),
                    StripFactoryDetails = _mapper.Map<ICollection<StripFactoryDetailModel>>(stripFactory.StripFactoryDetails),
                    StripScheduleDetails = _mapper.Map<ICollection<StripScheduleDetailModel>>(listSSD),
                    StripFactorySchedules = _mapper.Map<ICollection<StripFactoryScheduleModel>>(CalculateSFS),
                };
                #endregion

                if (request.LineId > 0)
                    return new(await CalculateForLineAsync(stripScheduleCalculate, stripFactory, calendarRes.Message, learningCurve, cancellationToken));

                return new(await CalculateForMachineAsync(stripScheduleCalculate, stripFactory, calendarRes.Message, learningCurve, cancellationToken));
            }

            return new($"Data Not True.");
        }

        private async Task<CalculateStripScheduleModel> CalculateForLineAsync(CalculateStripScheduleModel stripSchedule,
            StripFactory stripFactory, GetCalendarByIdResponse calendar, LearningCurveEfficiency learningCurveEfficiency, CancellationToken cancellationToken)
        {
            var lineRes = await _requestClientService
                .GetResponseAsync<GetLineByIdRequest, GetLineByIdResponse>(new(stripSchedule.LineId.Value), cancellationToken);

            var tempQuantity = stripSchedule.Quantity;
            var date = stripSchedule.FromDate;
            var hours = stripSchedule.FromWorkingHours;

            var tmp = 0;
            while (tempQuantity > 0)
            {
                var learningCurve = 1M;
                if (tmp < learningCurveEfficiency?.LearningCurveDetailEfficiencies.Count())
                {
                    learningCurve = (learningCurveEfficiency?.LearningCurveDetailEfficiencies.Select(x => x.EfficiencyValue).Skip(tmp).First()) ?? 1M;
                }

                var sspd = new StripSchedulePlanningDetailModel();

                var standardCapacity = (GetWorkingHours(calendar, date.DayOfWeek) * lineRes.Message.Worker) ?? 0M;
                var actualCapacity = (((lineRes.Message.Worker * hours) * (stripSchedule.ProfileEfficiencyValue ?? 1M)) * (stripSchedule.ProfileEfficiencyValue ?? 1M)) * learningCurve ?? 0M;

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
                hours = GetWorkingHours(calendar, date.DayOfWeek);
            }
            return stripSchedule;
        }

        private async Task<CalculateStripScheduleModel> CalculateForMachineAsync(CalculateStripScheduleModel stripSchedule,
            StripFactory stripFactory, GetCalendarByIdResponse calendar, LearningCurveEfficiency learningCurveEfficiency, CancellationToken cancellationToken)
        {
            var machineRes = await _requestClientService
                .GetResponseAsync<GetMachineByIdRequest, GetMachineByIdResponse>(new(stripSchedule.MachineId.Value), cancellationToken);

            var tempQuantity = stripSchedule.Quantity;
            var date = stripSchedule.FromDate;
            var hours = stripSchedule.FromWorkingHours;
            var tmp = 0;
            while (tempQuantity > 0)
            {
                var learningCurve = 1M;
                if (tmp < learningCurveEfficiency?.LearningCurveDetailEfficiencies.Count())
                {
                    learningCurve = (learningCurveEfficiency?.LearningCurveDetailEfficiencies.Select(x => x.EfficiencyValue).Skip(tmp).First()) ?? 1M;
                }
                var sspd = new StripSchedulePlanningDetailModel();

                var standardCapacity = (GetWorkingHours(calendar, date.DayOfWeek) * machineRes.Message.Capacity) ?? 0M;
                var actualCapacity = (((machineRes.Message.Capacity * hours) * stripSchedule.ProfileEfficiencyValue) * stripSchedule.OrderEfficiencyValue) * learningCurve ?? 0M;

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
                hours = GetWorkingHours(calendar, date.DayOfWeek);
            }
            return stripSchedule;
        }

        private static decimal GetWorkingHours(GetCalendarByIdResponse calendar, DayOfWeek dayOfWeek)
        {
            var dayDetail = calendar.CalendarDetails.FirstOrDefault(x => x.DayOfWeek == dayOfWeek);
            return dayDetail?.WorkingHours ?? 0;
        }
    }
}
