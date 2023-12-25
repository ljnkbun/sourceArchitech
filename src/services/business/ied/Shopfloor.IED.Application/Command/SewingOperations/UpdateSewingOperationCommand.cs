using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingOperations
{
    public class UpdateSewingOperationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { set; get; }
        public virtual ICollection<SewingOperationBOLModel> SewingOperationBOLs { get; set; }
    }
    public class UpdateSewingOperationCommandHandler : IRequestHandler<UpdateSewingOperationCommand, Response<int>>
    {
        private readonly ISewingOperationRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSewingOperationCommandHandler(ISewingOperationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingOperationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SewingOperation Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.LineCode = command.LineCode;
            entity.BundleTMU = command.BundleTMU;
            entity.ManualTMU = command.ManualTMU;
            entity.MachineTMU = command.MachineTMU;
            entity.TotalTMU = command.TotalTMU;
            entity.NoneMachineTime = command.NoneMachineTime;
            entity.LabourCost = command.LabourCost;
            entity.Deleted = command.Deleted;
            entity.IsActive = command.IsActive;
            entity.SewingOperationBOLs = null;

            var newSewingOperationBOLs = _mapper.Map<List<SewingOperationBOL>>(command.SewingOperationBOLs);
            foreach (var item in newSewingOperationBOLs ?? Enumerable.Empty<SewingOperationBOL>())
            {
                item.SewingOperationId = entity.Id;
            }

            await _repository.UpdateSewingOperationAsync(entity, newSewingOperationBOLs);
            return new Response<int>(entity.Id);
        }
    }
}
