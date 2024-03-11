using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.InspectionBySizes
{
    public class UpdateInspectionBySizeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? ProductionOutputId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public int? FPPOOutputDetailId { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ActualWeight { get; set; }
        public decimal? CaptureMeter { get; set; }
        public decimal? CuttingWidth { get; set; }
        public decimal? WarpDensity { get; set; }
        public decimal? WeftDensity { get; set; }
    }
    public class UpdateInspectionBySizeCommandHandler : IRequestHandler<UpdateInspectionBySizeCommand, Response<int>>
    {
        private readonly IInspectionBySizeRepository _repository;
        public UpdateInspectionBySizeCommandHandler(IInspectionBySizeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateInspectionBySizeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InspectionBySize Not Found.");

            entity.ProductionOutputId = command.ProductionOutputId;
            entity.CaptureMeter = command.CaptureMeter;
            entity.Weight = command.Weight;
            entity.WeftDensity = command.WeftDensity;
            entity.ActualWeight = command.ActualWeight;
            entity.ArticleBarcodeId = command.ArticleBarcodeId;
            entity.CuttingWidth = command.CuttingWidth;
            entity.FPPOOutputDetailId = command.FPPOOutputDetailId;
            entity.OKQty = command.OKQty;
            entity.BGroupQty = command.BGroupQty;
            entity.RejectQty = command.RejectQty;
            entity.Length = command.Length;
            entity.MadeQty = command.MadeQty;
            entity.WarpDensity = command.WarpDensity;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
