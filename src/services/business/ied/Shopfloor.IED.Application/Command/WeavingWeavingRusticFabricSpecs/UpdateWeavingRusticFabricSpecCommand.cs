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
        public string BackgroundType { get; set; }
        public decimal BackgroundLoomFrame { get; set; }
        public string BorderType { get; set; }
        public decimal BorderLoomFrame { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGM2 { get; set; }
        public decimal VerticalShrinkage { get; set; }
        public decimal HorizontalShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal RPM { get; set; }
        public decimal CombNum { get; set; }
        public decimal CombSize { get; set; }
        public decimal VerticalDensity { get; set; }
        public decimal HorizontalDensity { get; set; }
        public decimal RusticSize { get; set; }
        public decimal HorizontalDensitySetting { get; set; }
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

            if (entity == null) throw new ApiException($"WeavingRusticFabricSpec Not Found.");

            entity.LineNumber = command.LineNumber;
            entity.BackgroundType = command.BackgroundType;

            entity.BackgroundLoomFrame = command.BackgroundLoomFrame;
            entity.BorderType = command.BorderType;
            entity.BorderLoomFrame = command.BorderLoomFrame;
            entity.WeightGM = command.WeightGM;
            entity.WeightGM2 = command.WeightGM2;
            entity.VerticalShrinkage = command.VerticalShrinkage;
            entity.HorizontalShrinkage = command.HorizontalShrinkage;
            entity.MachineType = command.MachineType;
            entity.RPM = command.RPM;
            entity.CombNum = command.CombNum;
            entity.CombSize = command.CombSize;
            entity.VerticalDensity = command.VerticalDensity;
            entity.HorizontalDensity = command.HorizontalDensity;
            entity.RusticSize = command.RusticSize;
            entity.HorizontalDensitySetting = command.HorizontalDensitySetting;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
