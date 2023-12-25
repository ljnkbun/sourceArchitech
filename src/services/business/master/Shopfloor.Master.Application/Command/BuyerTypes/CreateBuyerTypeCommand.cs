using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.BuyerTypes
{
    public class CreateBuyerTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateBuyerTypeCommandHandler : IRequestHandler<CreateBuyerTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IBuyerTypeRepository _repository;
        public CreateBuyerTypeCommandHandler(IMapper mapper,
            IBuyerTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBuyerTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BuyerType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
