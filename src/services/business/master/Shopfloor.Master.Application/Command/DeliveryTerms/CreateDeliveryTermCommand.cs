using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.DeliveryTerms
{
    public class CreateDeliveryTermCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateDeliveryTermCommandHandler : IRequestHandler<CreateDeliveryTermCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryTermRepository _repository;
        public CreateDeliveryTermCommandHandler(IMapper mapper,
            IDeliveryTermRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDeliveryTermCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DeliveryTerm>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
