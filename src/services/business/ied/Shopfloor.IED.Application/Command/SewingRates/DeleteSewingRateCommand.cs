using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRates
{
    public class DeleteSewingRateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingRateCommandHandler : IRequestHandler<DeleteSewingRateCommand, Response<int>>
    {
        private readonly ISewingRateRepository _repository;
        public DeleteSewingRateCommandHandler(ISewingRateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingRateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingRate Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
