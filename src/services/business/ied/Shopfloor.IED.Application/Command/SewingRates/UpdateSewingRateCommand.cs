using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRates
{
    public class UpdateSewingRateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public decimal ExpectedQtyFrom { get; set; }
        public decimal ExpectedQtyTo { get; set; }
        public decimal EfficiencyRate { get; set; }
        public decimal CMRate { get; set; }
        public string Description { get; set; }
    }
    public class UpdateSewingRateCommandHandler : IRequestHandler<UpdateSewingRateCommand, Response<int>>
    {
        private readonly ISewingRateRepository _repository;
        public UpdateSewingRateCommandHandler(ISewingRateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSewingRateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingRate Not Found.");

            entity.ExpectedQtyFrom = command.ExpectedQtyFrom;
            entity.ExpectedQtyTo = command.ExpectedQtyTo;
            entity.EfficiencyRate = command.EfficiencyRate;
            entity.Description = command.Description;  
            entity.CMRate = command.CMRate;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
