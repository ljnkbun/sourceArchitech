using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.FPPOOutputDetails
{
    public class CreateFPPOOutputDetailCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? FPPOOutputId { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
    public class CreateFPPOOutputDetailCommandHandler : IRequestHandler<CreateFPPOOutputDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPOOutputDetailRepository _repository;
        public CreateFPPOOutputDetailCommandHandler(IMapper mapper,
            IFPPOOutputDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFPPOOutputDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FPPOOutputDetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
