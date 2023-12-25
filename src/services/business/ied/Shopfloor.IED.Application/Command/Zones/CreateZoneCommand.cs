using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Zones
{
    public class CreateZoneCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ZoneSalary { get; set; }

    }
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IZoneRepository _repository;
        public CreateZoneCommandHandler(IMapper mapper,
            IZoneRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Zone>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
