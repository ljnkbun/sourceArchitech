using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRusticFabricSpecs
{
    public class UpdateWeavingRusticFabricSpecCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public string ContentWeaveStyle { get; set; }
        public decimal HarnessFrameCWS { get; set; }
        public string MarginWeaveStyle { get; set; }
        public decimal HarnessFrameMWS { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGM2 { get; set; }
        public decimal WarpShrinkage { get; set; }
        public decimal WeftShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal RPM { get; set; }
        public decimal ReedCount { get; set; }
        public decimal ReedWidth { get; set; }
        public decimal WarpDensity { get; set; }
        public decimal WeftDensity { get; set; }
        public decimal GreigeWidth { get; set; }
        public decimal SettingWeftDensity { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingRusticFabricSpecCommandHandler : IRequestHandler<UpdateWeavingRusticFabricSpecCommand, Response<int>>
    {
        private readonly IWeavingRusticFabricSpecRepository _repository;
        public UpdateWeavingRusticFabricSpecCommandHandler(IWeavingRusticFabricSpecRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingRusticFabricSpecCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingRusticFabricSpec Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.ContentWeaveStyle = command.ContentWeaveStyle;
            entity.HarnessFrameCWS = command.HarnessFrameCWS;
            entity.MarginWeaveStyle = command.MarginWeaveStyle;
            entity.HarnessFrameMWS = command.HarnessFrameMWS;
            entity.WeightGM = command.WeightGM;
            entity.WeightGM2 = command.WeightGM2;
            entity.WarpShrinkage = command.WarpShrinkage;
            entity.WeftShrinkage = command.WeftShrinkage;
            entity.MachineType = command.MachineType;
            entity.RPM = command.RPM;
            entity.ReedCount = command.ReedCount;
            entity.ReedWidth = command.ReedWidth;
            entity.WarpDensity = command.WarpDensity;
            entity.WeftDensity = command.WeftDensity;
            entity.GreigeWidth = command.GreigeWidth;
            entity.SettingWeftDensity = command.SettingWeftDensity;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
