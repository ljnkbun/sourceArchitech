using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CompanyCurrencies
{
    public class CreateCompanyCurrencyCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime ValidFrom { get; set; }

    }
    public class CreateCompanyCurrencyCommandHandler : IRequestHandler<CreateCompanyCurrencyCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyCurrencyRepository _repository;
        public CreateCompanyCurrencyCommandHandler(IMapper mapper,
            ICompanyCurrencyRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCompanyCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CompanyCurrency>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
