using AutoMapper;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingOperationLibBOLModel> SewingOperationLibBOLs { get; set; }
    }
    public class UpdateSewingOperationLibCommandHandler : IRequestHandler<UpdateSewingOperationLibCommand, Response<int>>
    {
        private readonly ISewingOperationLibRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSewingOperationLibCommandHandler(IMapper mapper, ISewingOperationLibRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingOperationLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingOperationLib Not Found.");

            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.SubCategoryCode = command.SubCategoryCode;
            entity.SubCategoryName = command.SubCategoryName;
            entity.SewingComponentId = command.SewingComponentId;
            entity.BundleTMU = command.BundleTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.MachineTMU = command.MachineTMU;
            entity.PersonalAllowance = command.PersonalAllowance;
            entity.MachineDelay = command.MachineDelay;
            entity.Contingency = command.Contingency;
            entity.TotalSMV = command.TotalSMV;
            entity.NoneMachineTime = command.NoneMachineTime;
            entity.LabourCost = command.LabourCost;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingOperationLibBOLs = null;

            var newSewingOperationLibBOLs = _mapper.Map<ICollection<SewingOperationLibBOL>>(command.SewingOperationLibBOLs);
            foreach (var item in newSewingOperationLibBOLs ?? Enumerable.Empty<SewingOperationLibBOL>())
            {
                item.SewingOperationLibId = entity.Id;
                item.Id = 0;
            }

            await _repository.UpdateSewingOperationLibAsync(entity, newSewingOperationLibBOLs);
            return new Response<int>(entity.Id);
        }
    }
}
