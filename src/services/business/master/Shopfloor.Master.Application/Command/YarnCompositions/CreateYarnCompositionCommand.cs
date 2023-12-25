using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.YarnCompositions
{
    public class CreateYarnCompositionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateYarnCompositionCommandHandler : IRequestHandler<CreateYarnCompositionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IYarnCompositionRepository _repository;
        public CreateYarnCompositionCommandHandler(IMapper mapper,
            IYarnCompositionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateYarnCompositionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<YarnComposition>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
