using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Formulas
{
    public class DeleteFormulaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFormulaCommandHandler : IRequestHandler<DeleteFormulaCommand, Response<int>>
    {
        private readonly IFormulaRepository _repository;
        public DeleteFormulaCommandHandler(IFormulaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFormulaCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Formula Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
