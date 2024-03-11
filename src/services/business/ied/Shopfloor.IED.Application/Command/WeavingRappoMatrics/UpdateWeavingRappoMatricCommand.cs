using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappoMatrics
{
    public class UpdateWeavingRappoMatricCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int SlotIndex { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int LoopIndex { get; set; }
        public int HorizontalYarnId { get; set; }
        public int? VerticleYarnId { get; set; }
        public int BackgroundType { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingRappoMatricCommandHandler : IRequestHandler<UpdateWeavingRappoMatricCommand, Response<int>>
    {
        private readonly IWeavingRappoMatricRepository _repository;
        public UpdateWeavingRappoMatricCommandHandler(IWeavingRappoMatricRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingRappoMatricCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingRappoMatric Not Found.");

            entity.SlotIndex = command.SlotIndex;
            entity.RowIndex = command.RowIndex;
            entity.ColumnIndex = command.ColumnIndex;
            entity.LoopIndex = command.LoopIndex;
            entity.HorizontalYarnId = command.HorizontalYarnId;
            entity.VerticleYarnId = command.VerticleYarnId;
            entity.BackgroundType = command.BackgroundType;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
