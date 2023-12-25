using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorCards
{
    public class DeleteColorCardCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteColorCardCommandHandler : IRequestHandler<DeleteColorCardCommand, Response<int>>
    {
        private readonly IColorCardRepository _repository;
        public DeleteColorCardCommandHandler(IColorCardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteColorCardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ColorCard Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
