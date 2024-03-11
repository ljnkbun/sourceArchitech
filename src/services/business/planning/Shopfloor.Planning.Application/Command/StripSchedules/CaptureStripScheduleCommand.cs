using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class CaptureStripScheduleCommand : IRequest<Response<bool>>
    {
        public int ProcessId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class CaptureStripScheduleCommandHandler : IRequestHandler<CaptureStripScheduleCommand, Response<bool>>
    {
        private readonly IRequestClientService _requestClientService;
        private readonly IStripScheduleRepository _stripScheduleRepository;
        private readonly IStripScheduleCaptureRepository _stripScheduleCaptureRepository;
        private readonly IMapper _mapper;

        public CaptureStripScheduleCommandHandler(IStripScheduleRepository stripScheduleRepository,
            IRequestClientService requestClientService,
            IStripScheduleCaptureRepository stripScheduleCaptureRepository,
            IMapper mapper)
        {
            _requestClientService = requestClientService;
            _stripScheduleRepository = stripScheduleRepository;
            _stripScheduleCaptureRepository = stripScheduleCaptureRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CaptureStripScheduleCommand request, CancellationToken cancellationToken)
        {
            var processRes = await _requestClientService
                            .GetResponseAsync<GetProcessByIdRequest, GetProcessByIdResponse>(new() { Id = request.ProcessId }, cancellationToken);
            if (processRes == null || processRes.Message == null)
                return new($"Process Not Found. Id={request.ProcessId}");

            var stripSchedules = await _stripScheduleRepository.GetStripScheduleByPars(
                processRes.Message?.MachineIds, 
                processRes.Message?.LineIds, 
                request.FromDate, request.ToDate);

            var stripScheduleCapture = _mapper.Map<List<StripScheduleCapture>>(stripSchedules);
            var result = await _stripScheduleCaptureRepository.AddRangeAsync(stripScheduleCapture);

            return new Response<bool>(result);
        }
    }
}