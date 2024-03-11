using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CalendarDetails
{
    public class DeleteCalendarDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCalendarDetailCommandHandler : IRequestHandler<DeleteCalendarDetailCommand, Response<int>>
    {
        private readonly ICalendarDetailRepository _repository;
        public DeleteCalendarDetailCommandHandler(ICalendarDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCalendarDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"CalendarDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
