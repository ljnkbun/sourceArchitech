using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Gauges
{
    public class CreateGaugeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateGaugeCommandHandler : IRequestHandler<CreateGaugeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGaugeRepository _repository;
        public CreateGaugeCommandHandler(IMapper mapper,
            IGaugeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGaugeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Gauge>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
