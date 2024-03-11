using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.FormulaFields
{
    public class DeleteFormulaFieldCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFormulaFieldCommandHandler : IRequestHandler<DeleteFormulaFieldCommand, Response<int>>
    {
        private readonly IFormulaFieldRepository _repository;
        public DeleteFormulaFieldCommandHandler(IFormulaFieldRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFormulaFieldCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FormulaField Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
