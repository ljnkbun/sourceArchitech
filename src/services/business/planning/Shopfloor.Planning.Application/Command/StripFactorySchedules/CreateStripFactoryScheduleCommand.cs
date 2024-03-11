using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.StripFactoryDetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactorySchedules
{
    public class CreateStripFactoryScheduleCommand : IRequest<Response<bool>>
    {
        public int StripFactoryId { get; set; }
		public int? StripScheduleId { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNo { get; set; }

        public List<CreateStripFactoryDetailCommand> StripFactoryScheduleDetails { get; set; }
    }
    public class CreateStripFactoryScheduleCommandHandler : IRequestHandler<CreateStripFactoryScheduleCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryScheduleRepository _repository;
        private readonly IStripFactoryRepository _stripFactoryRepository;
        public CreateStripFactoryScheduleCommandHandler(IMapper mapper,
            IStripFactoryScheduleRepository repository,
            IStripFactoryRepository stripFactoryRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _stripFactoryRepository = stripFactoryRepository;
        }

        public async Task<Response<bool>> Handle(CreateStripFactoryScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StripFactorySchedule>(request);
            var stripFactory = await _stripFactoryRepository.GetByIdIncludeAsync(request.StripFactoryId);
            var result = await _repository.SplitBatchAsync(entity, stripFactory);
            return new Response<bool>(result);
        }
    }
}
