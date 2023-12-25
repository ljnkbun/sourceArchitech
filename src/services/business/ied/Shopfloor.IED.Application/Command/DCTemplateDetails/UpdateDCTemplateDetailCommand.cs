using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplateDetail
{
    public class UpdateDCTemplateDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DCTemplateTaskId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }
        public int LineNumber { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDCTemplateDetailCommandHandler : IRequestHandler<UpdateDCTemplateDetailCommand, Response<int>>
    {
        private readonly IDCTemplateDetailRepository _repository;

        public UpdateDCTemplateDetailCommandHandler(IDCTemplateDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateDCTemplateDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DCTemplateDetail Not Found.");

            entity.DCTemplateTaskId = command.DCTemplateTaskId;
            entity.Value = command.Value;
            entity.ChemicalCode = command.ChemicalCode;
            entity.ChemicalName = command.ChemicalName;
            entity.Unit = command.Unit;
            entity.LineNumber = command.LineNumber;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}