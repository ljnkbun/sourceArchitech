using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CompanyCurrencies
{
    public class UpdateCompanyCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime ValidFrom { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateCompanyCurrencyCommandHandler : IRequestHandler<UpdateCompanyCurrencyCommand, Response<int>>
    {
        private readonly ICompanyCurrencyRepository _repository;
        public UpdateCompanyCurrencyCommandHandler(ICompanyCurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateCompanyCurrencyCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"CompanyCurrency Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.RateExchange = command.RateExchange;
            entity.Symbol = command.Symbol;
            entity.ValidFrom = command.ValidFrom;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
