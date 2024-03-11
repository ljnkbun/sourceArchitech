using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.QCDefinitionDefects;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.QCDefinitions
{
    public class CreateQCDefinitionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal AcceptanceValue { get; set; }
		public int ConversionId { get; set; }
        public int QCTypeId { get; set; }
        public decimal? PercentQC { get; set; }
        public decimal? PercentAcceptance { get; set; }
        public decimal? FixedQty { get; set; }
        public decimal? AcceptanceQty { get; set; }
        public decimal? Quantity { get; set; }
        public int? AQLVersionId { get; set; }
        public int? FourPointsSystemId { get; set; }
        public int? OneHundredPointSystemId { get; set; }
        public ICollection<CreateQCDefinitionDefectCommand> QCDefinitionDefects { get; set; }
    }
    public class CreateQCDefinitionCommandHandler : IRequestHandler<CreateQCDefinitionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefinitionRepository _repository;
        public CreateQCDefinitionCommandHandler(IMapper mapper,
            IQCDefinitionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateQCDefinitionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<QCDefinition>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
