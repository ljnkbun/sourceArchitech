using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CompanyCurrencies
{
    public class DeleteCompanyCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCompanyCurrencyCommandHandler : IRequestHandler<DeleteCompanyCurrencyCommand, Response<int>>
    {
        private readonly ICompanyCurrencyRepository _repository;
        public DeleteCompanyCurrencyCommandHandler(ICompanyCurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCompanyCurrencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"CompanyCurrency Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
