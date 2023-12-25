using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.FormulaFields
{
    public class UpdateFormulaFieldCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string ProcessCode { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateFormulaFieldCommandHandler : IRequestHandler<UpdateFormulaFieldCommand, Response<int>>
    {
        private readonly IFormulaFieldRepository _repository;
        public UpdateFormulaFieldCommandHandler(IFormulaFieldRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFormulaFieldCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"FormulaField Not Found.");

            entity.FieldName = command.FieldName;
            entity.Description = command.Description;
            entity.ProcessCode = command.ProcessCode;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
