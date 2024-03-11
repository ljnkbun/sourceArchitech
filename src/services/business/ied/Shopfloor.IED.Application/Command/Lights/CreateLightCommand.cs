using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Lights
{
    public class CreateLightCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateLightCommandHandler : IRequestHandler<CreateLightCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ILightRepository _repository;
        public CreateLightCommandHandler(IMapper mapper,
            ILightRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLightCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Light>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
