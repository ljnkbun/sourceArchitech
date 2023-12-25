using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ShipmentTerms
{
    public class CreateShipmentTermCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateShipmentTermCommandHandler : IRequestHandler<CreateShipmentTermCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IShipmentTermRepository _repository;
        public CreateShipmentTermCommandHandler(IMapper mapper,
            IShipmentTermRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateShipmentTermCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ShipmentTerm>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
