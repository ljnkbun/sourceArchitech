using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.StripFactorySchedules;
using Shopfloor.Planning.Application.Command.StripScheduleDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class CreateStripScheduleCommand : IRequest<Response<int>>
    {
        public decimal? ProfileEfficiencyValue { get; set; }
        public decimal? OrderEfficiencyValue { get; set; }
        public decimal? StripEfficiencyValue { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public string Gauge { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public ICollection<CreateStripScheduleDetailCommand> StripScheduleDetails { get; set; }
        public ICollection<CreateStripFactoryScheduleCommand> StripFactorySchedules { get; set; }
    }
    public class CreateStripScheduleCommandHandler : IRequestHandler<CreateStripScheduleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripScheduleRepository _repository;
        public CreateStripScheduleCommandHandler(IMapper mapper,
            IStripScheduleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStripScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StripSchedule>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
