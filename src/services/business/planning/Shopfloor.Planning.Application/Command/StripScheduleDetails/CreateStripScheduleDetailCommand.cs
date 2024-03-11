using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripScheduleDetails
{
    public class CreateStripScheduleDetailCommand : IRequest<Response<int>>
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int StripScheduleId { get; set; }

    }
    public class CreateStripScheduleDetailCommandHandler : IRequestHandler<CreateStripScheduleDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripScheduleDetailRepository _repository;
        public CreateStripScheduleDetailCommandHandler(IMapper mapper,
            IStripScheduleDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStripScheduleDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StripScheduleDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
