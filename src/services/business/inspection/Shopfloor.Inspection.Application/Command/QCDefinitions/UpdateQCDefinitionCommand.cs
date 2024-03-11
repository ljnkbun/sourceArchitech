using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.QCDefinitionDefects;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.QCDefinitions
{
    public class UpdateQCDefinitionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal AcceptanceValue { get; set; }
		public int SamplingId { get; set; }
		public int ConversionId { get; set; }
        public bool IsActive { set; get; }
        public int QCTypeId { get; set; }
        public ICollection<UpdateQCDefinitionDefectCommand> QCDefinitionDefects { get; set; }
        public decimal? PercentQC { get; set; }
        public decimal? PercentAcceptance { get; set; }
        public decimal? FixedQty { get; set; }
        public decimal? AcceptanceQty { get; set; }
        public decimal? Quantity { get; set; }
        public int? AQLVersionId { get; set; }
        public int? FourPointsSystemId { get; set; }
        public int? OneHundredPointSystemId { get; set; }
    }
    public class UpdateQCDefinitionCommandHandler : IRequestHandler<UpdateQCDefinitionCommand, Response<int>>
    {
        private readonly IQCDefinitionRepository _repository;
        private readonly IQCDefinitionDefectRepository _repositoryQCDefinitionDefect;
        private readonly IMapper _mapper;

        public UpdateQCDefinitionCommandHandler(IMapper mapper, IQCDefinitionRepository repository, IQCDefinitionDefectRepository repositoryQCDefinitionDefect)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryQCDefinitionDefect = repositoryQCDefinitionDefect;
        }
        public async Task<Response<int>> Handle(UpdateQCDefinitionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new ($"QCDefinition Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.Buyer = command.Buyer;
			entity.Category = command.Category;
			entity.AcceptanceValue = command.AcceptanceValue;
			entity.ConversionId = command.ConversionId;
            entity.QCTypeId = command.QCTypeId;
            entity.PercentQC= command.PercentQC;
            entity.PercentAcceptance= command.PercentAcceptance;
            entity.FixedQty= command.FixedQty;
            entity.AcceptanceQty= command.AcceptanceQty;
            entity.Quantity= command.Quantity;
            entity.AQLVersionId = command.AQLVersionId;
            entity.FourPointsSystemId   = command.FourPointsSystemId;
            entity.OneHundredPointSystemId= command.OneHundredPointSystemId;
            var dbQCDefinitionDefect = await _repositoryQCDefinitionDefect.GetByQCDefinitionIdAsync(command.Id);
            var insertedQCDefinitionDefects = _mapper.Map<ICollection<QCDefinitionDefect>>(command.QCDefinitionDefects);
            await _repository.UpdateQCDefinitionsync(entity, dbQCDefinitionDefect, insertedQCDefinitionDefects);
            return new Response<int>(entity.Id);
        }
    }
}
