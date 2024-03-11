using MediatR;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Master.Application.Command.Holidays
{
    public class UpdateHolidayCommand : IRequest<Response<int>>
    {
        public DateTime? Date { get; set; }
		public string Description { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommand, Response<int>>
    {
        private readonly IHolidayRepository _repository;
        public UpdateHolidayCommandHandler(IHolidayRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateHolidayCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Holiday Not Found.");
            entity.IsActive = command.IsActive;
            entity.Date = command.Date;
			entity.Description = command.Description;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
