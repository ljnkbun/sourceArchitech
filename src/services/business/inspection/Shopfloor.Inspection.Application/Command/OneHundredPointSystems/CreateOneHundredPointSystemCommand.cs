using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.OneHundredPointSystems
{
    public class CreateOneHundredPointSystemCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
    public class CreateOneHundredPointSystemCommandHandler : IRequestHandler<CreateOneHundredPointSystemCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IOneHundredPointSystemRepository _repository;
        public CreateOneHundredPointSystemCommandHandler(IMapper mapper,
            IOneHundredPointSystemRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOneHundredPointSystemCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OneHundredPointSystem>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
