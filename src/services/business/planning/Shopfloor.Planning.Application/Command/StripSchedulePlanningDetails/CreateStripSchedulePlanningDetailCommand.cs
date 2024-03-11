using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails
{
    public class CreateStripSchedulePlanningDetailCommand : IRequest<Response<int>>
    {
        public DateTime Date { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal StandardCapacity { get; set; }
        public decimal ActualCapacity { get; set; }
        public decimal ReceivedCapacity { get; set; }
        public string Description { get; set; }
        public int StripScheduleId { get; set; }

    }
    public class CreateStripSchedulePlanningDetailCommandHandler : IRequestHandler<CreateStripSchedulePlanningDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripSchedulePlanningDetailRepository _repository;
        public CreateStripSchedulePlanningDetailCommandHandler(IMapper mapper,
            IStripSchedulePlanningDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStripSchedulePlanningDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StripSchedulePlanningDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
