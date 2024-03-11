using MediatR;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Master.Application.Command.Holidays
{
    public class DeleteHolidayCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand, Response<int>>
    {
        private readonly IHolidayRepository _repository;
        public DeleteHolidayCommandHandler(IHolidayRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteHolidayCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Holiday Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
