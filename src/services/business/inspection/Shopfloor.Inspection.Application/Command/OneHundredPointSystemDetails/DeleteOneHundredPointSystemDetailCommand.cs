using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.OneHundredPointSystemDetails
{
    public class DeleteOneHundredPointSystemDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteOneHundredPointSystemDetailCommandHandler : IRequestHandler<DeleteOneHundredPointSystemDetailCommand, Response<int>>
    {
        private readonly IOneHundredPointSystemDetailRepository _repository;
        public DeleteOneHundredPointSystemDetailCommandHandler(IOneHundredPointSystemDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteOneHundredPointSystemDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"OneHundredPointSystemDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
