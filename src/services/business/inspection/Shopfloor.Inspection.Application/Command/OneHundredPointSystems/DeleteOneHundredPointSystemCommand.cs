using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.OneHundredPointSystems
{
    public class DeleteOneHundredPointSystemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteOneHundredPointSystemCommandHandler : IRequestHandler<DeleteOneHundredPointSystemCommand, Response<int>>
    {
        private readonly IOneHundredPointSystemRepository _repository;
        public DeleteOneHundredPointSystemCommandHandler(IOneHundredPointSystemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteOneHundredPointSystemCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"OneHundredPointSystem Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
