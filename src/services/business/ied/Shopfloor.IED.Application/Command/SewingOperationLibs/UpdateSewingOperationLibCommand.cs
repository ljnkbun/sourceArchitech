using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationLibs
{
    public class UpdateSewingOperationLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingOperationLibBOLModel> SewingOperationLibBOLs { get; set; }
    }
    public class UpdateSewingOperationLibCommandHandler : IRequestHandler<UpdateSewingOperationLibCommand, Response<int>>
    {
        private readonly ISewingOperationLibRepository _repository;
        private readonly ISewingOperationLibBOLRepository _bolRepository;

        public UpdateSewingOperationLibCommandHandler(ISewingOperationLibRepository repository, ISewingOperationLibBOLRepository bolRepository)
        {
            _repository = repository;
            _bolRepository = bolRepository;
        }
        public async Task<Response<int>> Handle(UpdateSewingOperationLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingOperationLib Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.BundleTMU = command.BundleTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.MachineTMU = command.MachineTMU;
            entity.TotalTMU = command.TotalTMU;
            entity.NoneMachineTime = command.NoneMachineTime;
            entity.LabourCost = command.LabourCost;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingOperationLibBOLs = null;

            var deleteItems = await _bolRepository.GetListAsync(command.Id);                                                                                                           // || !command.ProductCategories.Any(v => v.Id == x.Id)).ToList();
            var insertItems = command.SewingOperationLibBOLs?.Select(x => new SewingOperationLibBOL
            {
                SewingOperationLibId = command.Id,
                SewingMacroLibId = x.SewingMacroLibId,
                SewingTaskLibId = x.SewingTaskLibId,
                LineNumber = x.LineNumber,
                Freq = x.Freq,
                TotalTMU = x.TotalTMU
            }).ToList();

            await _repository.UpdateSewingOperationLibAsync(entity, insertItems, deleteItems);
            return new Response<int>(entity.Id);
        }
    }
}
