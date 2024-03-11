using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Command.FPPODetails;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.FPPOs
{
    public class CreateFPPOCommand : IRequest<Response<int>>
    {
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
        public virtual ICollection<CreateFPPODetailCommand> FPPODetails { get; set; }
    }
    public class CreateFPPOCommandHandler : IRequestHandler<CreateFPPOCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPORepository _repository;
        public CreateFPPOCommandHandler(IMapper mapper
            , IFPPORepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateFPPOCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FPPO>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
