using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingGreiges
{
    public class CreateKnittingGreigeCommand : IRequest<Response<int>>
    {
        public int KnittingIEDId { get; set; }
        public int KnittingBodyTypeId { get; set; }
        public int KnittingTypeId { get; set; }
        public decimal Width { get; set; }
        public decimal WidthLossRate { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGMLossRate { get; set; }
        public decimal VerticalDensity { get; set; }
        public decimal VerticalDensityLossRate { get; set; }
        public decimal HorizontalDensity { get; set; }
        public decimal HorizontalDensityLossRate { get; set; }
        public decimal WrapShrinkage { get; set; }
        public int KnittingShrinkageId { get; set; }
        public decimal WeftShrinkage { get; set; }
        public int Gauge { get; set; }
        public decimal Feeder { get; set; }
        public decimal UsedFeeder { get; set; }
        public decimal Needle { get; set; }
        public decimal RappoLength { get; set; }
        public decimal MachineDiameter { get; set; }
        public decimal WeightKg { get; set; }
    }
    public class CreateKnittingGreigeCommandHandler : IRequestHandler<CreateKnittingGreigeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingGreigeRepository _repository;
        public CreateKnittingGreigeCommandHandler(IMapper mapper,
            IKnittingGreigeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingGreigeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingGreige>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
