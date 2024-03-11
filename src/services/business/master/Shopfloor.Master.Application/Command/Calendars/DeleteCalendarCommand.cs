using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Calendars
{
    public class DeleteCalendarCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCalendarCommandHandler : IRequestHandler<DeleteCalendarCommand, Response<int>>
    {
        private readonly ICalendarRepository _repository;
        public DeleteCalendarCommandHandler(ICalendarRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCalendarCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Calendar Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
