using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRates
{
    public class CreateSewingRateCommand : IRequest<Response<int>>
    {
        public decimal ExpectedQtyFrom { get; set; }
        public decimal ExpectedQtyTo { get; set; }
        public decimal EfficiencyRate { get; set; }
        public decimal CMRate { get; set; }
        public string Description { get; set; }
    }
    public class CreateSewingRateCommandHandler : IRequestHandler<CreateSewingRateCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingRateRepository _repository;
        public CreateSewingRateCommandHandler(IMapper mapper,
            ISewingRateRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingRateCommand sewingRate, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingRate>(sewingRate);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
