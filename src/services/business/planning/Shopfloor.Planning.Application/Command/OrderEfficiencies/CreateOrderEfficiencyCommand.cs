using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.OrderEfficiencies
{
    public class CreateOrderEfficiencyCommand : IRequest<Response<int>>
    {
        public string OCNo { get; set; }
        public decimal EfficiencyValue { get; set; }

    }
    public class CreateOrderEfficiencyCommandHandler : IRequestHandler<CreateOrderEfficiencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderEfficiencyRepository _repository;
        public CreateOrderEfficiencyCommandHandler(IMapper mapper,
            IOrderEfficiencyRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOrderEfficiencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderEfficiency>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
