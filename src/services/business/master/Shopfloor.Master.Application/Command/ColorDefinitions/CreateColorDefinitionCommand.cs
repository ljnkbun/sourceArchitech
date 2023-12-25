using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorDefinitions
{
    public class CreateColorDefinitionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateColorDefinitionCommandHandler : IRequestHandler<CreateColorDefinitionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IColorDefinitionRepository _repository;
        public CreateColorDefinitionCommandHandler(IMapper mapper,
            IColorDefinitionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateColorDefinitionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ColorDefinition>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
