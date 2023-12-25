using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PricePers
{
    public class CreatePricePerCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreatePricePerCommandHandler : IRequestHandler<CreatePricePerCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPricePerRepository _repository;
        public CreatePricePerCommandHandler(IMapper mapper,
            IPricePerRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePricePerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PricePer>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
