using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperationWFXs
{
    public class CreateSewingOperationWFXCommand : IRequest<Response<int>>
    {
        public int RequestDivisionProcessId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string Buyer { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal FactoryTime { get; set; }
        public decimal LabourCostOp { get; set; }
        public decimal LabourCostFactory { get; set; }
        public decimal FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal LabourCostFactoryIncludingOverhead { get; set; }
        public Status Status { get; set; }
    }
    public class CreateSewingOperationWFXCommandHandler : IRequestHandler<CreateSewingOperationWFXCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationWFXRepository _repository;
        public CreateSewingOperationWFXCommandHandler(IMapper mapper,
            ISewingOperationWFXRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingOperationWFXCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingOperationWFX>(request);
            await _repository.AddSewingOperationWFXAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
