using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails
{
    public class DeleteStripSchedulePlanningDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStripSchedulePlanningDetailCommandHandler : IRequestHandler<DeleteStripSchedulePlanningDetailCommand, Response<int>>
    {
        private readonly IStripSchedulePlanningDetailRepository _repository;
        public DeleteStripSchedulePlanningDetailCommandHandler(IStripSchedulePlanningDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStripSchedulePlanningDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"StripSchedulePlanningDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
