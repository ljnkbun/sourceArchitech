using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripScheduleDetails
{
    public class DeleteStripScheduleDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStripScheduleDetailCommandHandler : IRequestHandler<DeleteStripScheduleDetailCommand, Response<int>>
    {
        private readonly IStripScheduleDetailRepository _repository;
        public DeleteStripScheduleDetailCommandHandler(IStripScheduleDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStripScheduleDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"StripScheduleDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
