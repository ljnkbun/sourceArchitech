using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Message;
using Shopfloor.Master.Application.Command.CalendarDetails;
using Shopfloor.Master.Application.Settings;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Calendars
{
    public class UpdateCalendarCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateCalendarDetailCommand> CalendarDetails { get; set; }
    }
    public class UpdateCalendarCommandHandler : IRequestHandler<UpdateCalendarCommand, Response<int>>
    {
        private readonly ICalendarRepository _repository;
        private readonly IMapper _mapper;
        public UpdateCalendarCommandHandler(ICalendarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateCalendarCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Calendar Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CalendarDetails = _mapper.Map<ICollection<CalendarDetail>>(command.CalendarDetails);
            entity.IsActive = command.IsActive;

            await _repository.UpdateProfileEfficiencyAsync(entity, entity.CalendarDetails);

            return new Response<int>(entity.Id);
        }
    }
}
