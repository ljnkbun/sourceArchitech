using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingGreiges
{
    public class UpdateKnittingGreigeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
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
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingGreigeCommandHandler : IRequestHandler<UpdateKnittingGreigeCommand, Response<int>>
    {
        private readonly IKnittingGreigeRepository _repository;
        public UpdateKnittingGreigeCommandHandler(IKnittingGreigeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingGreigeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingGreige Not Found.");

            entity.KnittingBodyTypeId = command.KnittingBodyTypeId;
            entity.KnittingTypeId = command.KnittingTypeId;
            entity.Width = command.Width;
            entity.WidthLossRate = command.WidthLossRate;
            entity.WeightGM = command.WeightGM;
            entity.WeightGMLossRate = command.WeightGMLossRate;
            entity.VerticalDensity = command.VerticalDensity;
            entity.VerticalDensityLossRate = command.VerticalDensityLossRate;
            entity.WrapShrinkage = command.WrapShrinkage;
            entity.KnittingShrinkageId = command.KnittingShrinkageId;
            entity.WeftShrinkage = command.WeftShrinkage;
            entity.Gauge = command.Gauge;
            entity.Feeder = command.Feeder;
            entity.UsedFeeder = command.UsedFeeder;
            entity.Needle = command.Needle;
            entity.RappoLength = command.RappoLength;
            entity.MachineDiameter = command.MachineDiameter;
            entity.WeightKg = command.WeightKg;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
