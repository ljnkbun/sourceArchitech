using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SizeOrWidthRanges
{
    public class DeleteSizeOrWidthRangeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSizeOrWidthRangeCommandHandler : IRequestHandler<DeleteSizeOrWidthRangeCommand, Response<int>>
    {
        private readonly ISizeOrWidthRangeRepository _repository;
        public DeleteSizeOrWidthRangeCommandHandler(ISizeOrWidthRangeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSizeOrWidthRangeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SizeOrWidthRange Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
