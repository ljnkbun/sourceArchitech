using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactoryScheduleDetails
{
    public class CreateStripFactoryScheduleDetailCommand : IRequest<Response<int>>
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripFactoryScheduleId { get; set; }
    }
    public class CreateStripFactoryScheduleDetailCommandHandler : IRequestHandler<CreateStripFactoryScheduleDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryScheduleDetailRepository _repository;
        public CreateStripFactoryScheduleDetailCommandHandler(IMapper mapper,
            IStripFactoryScheduleDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStripFactoryScheduleDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StripFactoryScheduleDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
