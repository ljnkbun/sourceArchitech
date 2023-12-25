using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PricePers
{
    public class DeletePricePerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePricePerCommandHandler : IRequestHandler<DeletePricePerCommand, Response<int>>
    {
        private readonly IPricePerRepository _repository;
        public DeletePricePerCommandHandler(IPricePerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeletePricePerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"PricePer Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
