using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Structures
{
    public class CreateStructureCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateStructureCommandHandler : IRequestHandler<CreateStructureCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStructureRepository _repository;
        public CreateStructureCommandHandler(IMapper mapper,
            IStructureRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateStructureCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Structure>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
