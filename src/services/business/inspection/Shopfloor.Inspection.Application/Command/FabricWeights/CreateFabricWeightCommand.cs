using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.FabricWeights
{
    public class CreateFabricWeightCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
    public class CreateFabricWeightCommandHandler : IRequestHandler<CreateFabricWeightCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFabricWeightRepository _repository;
        public CreateFabricWeightCommandHandler(IMapper mapper,
            IFabricWeightRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFabricWeightCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FabricWeight>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
