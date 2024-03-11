using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingMachineDiameters
{
    public class CreateKnittingMachineDiameterCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateKnittingMachineDiameterCommandHandler : IRequestHandler<CreateKnittingMachineDiameterCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingMachineDiameterRepository _repository;
        public CreateKnittingMachineDiameterCommandHandler(IMapper mapper,
            IKnittingMachineDiameterRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingMachineDiameterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingMachineDiameter>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
