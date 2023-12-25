using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingSubOperationWFXs
{
    public class UpdateSewingSubOperationWFXCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string LineNumber { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal NonMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public string QuatityPoints { get; set; }
        public string QualityComments { get; set; }
        public string Freq { get; set; }
        public decimal Effort { get; set; }
        public decimal AllowedTime { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingSubOperationWFXBOLModel> SewingSubOperationWFXBOLs { get; set; }
    }
    public class UpdateSewingSubOperationWFXCommandHandler : IRequestHandler<UpdateSewingSubOperationWFXCommand, Response<int>>
    {
        private readonly ISewingSubOperationWFXRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSewingSubOperationWFXCommandHandler(ISewingSubOperationWFXRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingSubOperationWFXCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingSubOperationWFX Not Found.");

            entity.WFXProcessCode = command.WFXProcessCode;
            entity.WFXProcessName = command.WFXProcessName;
            entity.LineNumber = command.LineNumber;
            entity.LineCode = command.LineCode;
            entity.Description = command.Description;
            entity.BundleTMU = command.BundleTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.MachineTMU = command.MachineTMU;
            entity.TotalSMV = command.TotalSMV;
            entity.NonMachineTime = command.NonMachineTime;
            entity.LabourCost = command.LabourCost;
            entity.QuatityPoints = command.QuatityPoints;
            entity.QualityComments = command.QualityComments;
            entity.Freq = command.Freq;
            entity.Effort = command.Effort;
            entity.AllowedTime = command.AllowedTime;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingSubOperationWFXBOLs = null;

            var newSewingSubOperationWFXBOLs = _mapper.Map<List<SewingSubOperationWFXBOL>>(command.SewingSubOperationWFXBOLs);
            foreach (var item in newSewingSubOperationWFXBOLs ?? Enumerable.Empty<SewingSubOperationWFXBOL>())
            {
                item.SewingSubOperationWFXId = entity.Id;
            }

            await _repository.UpdateSewingSubOperationWFXAsync(entity, newSewingSubOperationWFXBOLs);
            return new Response<int>(entity.Id);
        }
    }
}
