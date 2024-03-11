using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Command.FPPOOutputDetails;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.FPPOOutputs
{
    public class UpdateFPPOOutputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? WFXArticleId { get; set; }
        public int? FPPOId { get; set; }
        public string FPPONo { get; set; }
        public string OCNo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public int? PORId { get; set; }
        public string PORNo { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public int? OperationId { get; set; }
        public string OperationCode { get; set; }
        public string OperationName { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public int? QCDefinationId { get; set; }
        public string QCName { get; set; }
        public string UOM { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public virtual ICollection<UpdateFPPOOutputDetailCommand> FPPODetails { get; set; }
    }
    public class UpdateFPPOOutputCommandHandler : IRequestHandler<UpdateFPPOOutputCommand, Response<int>>
    {
        private readonly IFPPOOutputRepository _repository;
        public UpdateFPPOOutputCommandHandler(IFPPOOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFPPOOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"FPPOOutput Not Found.");

            entity.ProcessId = command.ProcessId;
            entity.ProcessCode = command.ProcessCode;
            entity.ProcessName = command.ProcessName;
            entity.PORId = command.PORId;
            entity.PORNo = command.PORNo;
            entity.OCNo = command.OCNo;
            entity.FPPONo = command.FPPONo;
            entity.FPPOId = command.FPPOId;
            entity.OperationId = command.OperationId;
            entity.OperationCode = command.OperationCode;
            entity.OperationName = command.OperationName;
            entity.LineId = command.LineId;
            entity.MachineId = command.MachineId;
            entity.QCDefinationId = command.QCDefinationId;
            entity.QCName = command.QCName;
            entity.Start = command.Start;
            entity.End = command.End;
            entity.UOM = command.UOM;
            entity.BatchNo = command.BatchNo;
            entity.JobOrderNo = command.JobOrderNo;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
