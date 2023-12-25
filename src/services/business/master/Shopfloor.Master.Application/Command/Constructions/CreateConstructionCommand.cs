using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Constructions
{
    public class CreateConstructionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateConstructionCommandHandler : IRequestHandler<CreateConstructionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IConstructionRepository _repository;
        public CreateConstructionCommandHandler(IMapper mapper,
            IConstructionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateConstructionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Construction>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
