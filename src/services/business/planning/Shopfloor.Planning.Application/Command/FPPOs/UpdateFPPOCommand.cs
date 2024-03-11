using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.FPPODetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.FPPOs
{
    public class UpdateFPPOCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int StripScheduleId { get; set; }
        public int? WFXFPPOId { get; set; }
        public string FPPONo { get; set; }
        public int? WFXOCId { get; set; }
        public string OCNo { get; set; }
        public string WFXDeliveryOrderCode { get; set; }
        public string Supplier { get; set; }
        public string WipDispatchSite { get; set; }
        public string WipReceivingSite { get; set; }
        public int PORId { get; set; }
        public string PORNo { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public int? FactoryId { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string UOM { get; set; }
        public virtual ICollection<UpdateFPPODetailCommand> FPPODetails { get; set; }
    }
    public class UpdateFPPOCommandHandler : IRequestHandler<UpdateFPPOCommand, Response<int>>
    {
        private readonly IFPPORepository _repository;
        private readonly IMapper _mapper;
        public UpdateFPPOCommandHandler(IFPPORepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateFPPOCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"FPPO Not Found.");

            entity.StripScheduleId = command.StripScheduleId;
            entity.WFXFPPOId = command.WFXFPPOId;
            entity.FPPONo = command.FPPONo;
            entity.WFXOCId = command.WFXOCId;
            entity.OCNo = command.OCNo;
            entity.WFXDeliveryOrderCode = command.WFXDeliveryOrderCode;
            entity.Supplier = command.Supplier;
            entity.WipDispatchSite = command.WipDispatchSite;
            entity.WipReceivingSite = command.WipReceivingSite;
            entity.PORId = command.PORId;
            entity.PORNo = command.PORNo;
            entity.BatchNo = command.BatchNo;
            entity.JobOrderNo = command.JobOrderNo;
            entity.FactoryId = command.FactoryId;
            entity.LineId = command.LineId;
            entity.MachineId = command.MachineId;
            entity.ProcessId = command.ProcessId;
            entity.ProcessCode = command.ProcessCode;
            entity.ProcessName = command.ProcessName;
            entity.Start = command.Start;
            entity.End = command.End;
            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.UOM = command.UOM;
            entity.FPPODetails = null;

            var newFPPODetails = _mapper.Map<ICollection<FPPODetail>>(command.FPPODetails);
            foreach (var item in newFPPODetails ?? Enumerable.Empty<FPPODetail>())
            {
                item.FPPOId = entity.Id;
                item.Id = 0;
            }
            await _repository.UpdateFPPOAsync(entity, newFPPODetails);
            return new Response<int>(entity.Id);
        }
    }
}
