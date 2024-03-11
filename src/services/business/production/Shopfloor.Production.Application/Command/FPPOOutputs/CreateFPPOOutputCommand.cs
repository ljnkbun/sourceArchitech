using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Command.FPPOOutputDetails;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.FPPOOutputs
{
    public class CreateFPPOOutputCommand : IRequest<Response<int>>
    {
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

        public virtual ICollection<CreateFPPOOutputDetailCommand> FPPODetails { get; set; }
    }
    public class CreateFPPOOutputCommandHandler : IRequestHandler<CreateFPPOOutputCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPOOutputRepository _repository;
        public CreateFPPOOutputCommandHandler(IMapper mapper,
            IFPPOOutputRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFPPOOutputCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FPPOOutput>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
