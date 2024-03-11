using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.ZoneTypes
{
    public class CreateZoneTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
    public class CreateZoneTypeCommandHandler : IRequestHandler<CreateZoneTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IZoneTypeRepository _repository;
        public CreateZoneTypeCommandHandler(IMapper mapper,
            IZoneTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateZoneTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ZoneType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
