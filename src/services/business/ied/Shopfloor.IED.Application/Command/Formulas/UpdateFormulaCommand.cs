using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Formulas
{
    public class UpdateFormulaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }
        public string ProcessCode { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateFormulaCommandHandler : IRequestHandler<UpdateFormulaCommand, Response<int>>
    {
        private readonly IFormulaRepository _repository;
        public UpdateFormulaCommandHandler(IFormulaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFormulaCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"Formula Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.Expression = command.Expression;
            entity.ProcessCode = command.ProcessCode;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
