using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Currencies
{
    public class CreateCurrencyCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _repository;
        public CreateCurrencyCommandHandler(IMapper mapper,
            ICurrencyRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Currency>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
