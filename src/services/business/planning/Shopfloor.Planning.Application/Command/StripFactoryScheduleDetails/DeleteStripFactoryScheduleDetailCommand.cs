using MediatR;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.StripFactoryScheduleDetails
{
    public class DeleteStripFactoryScheduleDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStripFactoryScheduleDetailCommandHandler : IRequestHandler<DeleteStripFactoryScheduleDetailCommand, Response<int>>
    {
        private readonly IStripFactoryScheduleDetailRepository _repository;
        public DeleteStripFactoryScheduleDetailCommandHandler(IStripFactoryScheduleDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStripFactoryScheduleDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"StripFactoryScheduleDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
