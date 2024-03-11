using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingDetailStructures
{
    public class UpdateWeavingDetailStructureCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? LineNumber { get; set; }
        public StructureType StructureType { get; set; }
        public int Denting { get; set; }
        public int DentSplit { get; set; }
        public int Total { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingDetailStructureCommandHandler : IRequestHandler<UpdateWeavingDetailStructureCommand, Response<int>>
    {
        private readonly IWeavingDetailStructureRepository _repository;
        public UpdateWeavingDetailStructureCommandHandler(IWeavingDetailStructureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingDetailStructureCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingDetailStructure Not Found.");

            entity.StructureType = command.StructureType;
            entity.LineNumber = command.LineNumber;
            entity.Denting = command.Denting;
            entity.DentSplit = command.DentSplit;
            entity.Total = command.Total;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
