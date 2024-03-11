using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.CriticalParts
{
    public class CreateCriticalPartCommand : IRequest<Response<int>>
    {
		public int PlanningGroupId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int Priority { get; set; }
	}
    public class CreateCriticalPartCommandHandler : IRequestHandler<CreateCriticalPartCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICriticalPartRepository _repository;
        public CreateCriticalPartCommandHandler(IMapper mapper, ICriticalPartRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateCriticalPartCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CriticalPart>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
