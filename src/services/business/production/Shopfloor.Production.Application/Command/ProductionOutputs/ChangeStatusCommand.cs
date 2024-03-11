using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Enums;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.ProductionOutputs
{
    public class ChangeStatusCommand : IRequest<Response<bool>>
    {
        public int[] Ids { get; set; }
        public WFXExportStatus? WFXExportStatus { get; set; }
        public SaveStatus? Status { get; set; }

    }
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, Response<bool>>
    {
        private readonly IProductionOutputRepository _repository;

        public ChangeStatusCommandHandler(IProductionOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(ChangeStatusCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdsAsync(command.Ids);

            if (entities == null || !entities.Any()) return new($"ProductionOutput Not Found.");

            foreach (var entity in entities)
            {
                entity.WFXExportStatus = command.WFXExportStatus;
                entity.Status = command.Status;
                if (command.WFXExportStatus == WFXExportStatus.Transfered)
                {
                    entity.Status = SaveStatus.Actual;
                }

            }
            await _repository.UpdateRangeAsync(entities.ToList());

            return new Response<bool>(true);
        }
    }
}
