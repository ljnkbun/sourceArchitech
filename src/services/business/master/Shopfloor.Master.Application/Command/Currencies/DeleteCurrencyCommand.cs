using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Currencies
{
    public class DeleteCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, Response<int>>
    {
        private readonly ICurrencyRepository _repository;
        public DeleteCurrencyCommandHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCurrencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Currency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
